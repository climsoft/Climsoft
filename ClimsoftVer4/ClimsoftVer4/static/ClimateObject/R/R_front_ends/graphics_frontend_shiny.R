#############################################################################
# SHINY-INTERFACE THROUGH R TO PLOT GRAPHICS
#' @title SHINY Graphic Frontend
#' @name graphics_frontend_shiny
#' @description Creates a UI interface using \code{shiny})
#' @author Rafael Posada, 2015 (SASSCAL/DWD)
#' 
climate$methods(graphics_frontend_shiny = function(selected_plot="Timeseries"){
  ###########################################################################
  # Required packages
  library(shiny)
  
  ###########################################################################
  # Create UI interface 
  ui <- basicPage(
    uiOutput("tabs1"),
    uiOutput("minVal"),
    uiOutput("maxVal"),
    uiOutput("slider")
  )
  
  ###########################################################################
  # server.R
  server <- function(input, output) {
    
    #########################################################################
    # PLOT PART (1/2)
    
    # If selected_plot == Timeseries
    if (selected_plot=="Timeseries"){
      # Run the function that creates the list of graphics
      k <- .self$timeseries_shiny()
      # Create a new function to be used as dygraphOutput
      graphOutput <- function(outputID,width="100%",height="280"){
        dygraphOutput(outputID,width,height)
      }
    }
    
    # If selected_plot == Histogram
    if (selected_plot=="Histogram"){
      # Run the function that creates the list of graphics
      k <- .self$histogram_shiny()
      
      # Create a new function to be used as ggvisOutput
      graphOutput <- as.function(ggvisOutput)
      
      # Create reactive inputs for histogram
      output$minVal <- renderUI({
        numericInput("minValue", "Minimum_value",.1)
      })
      output$maxVal <- renderUI({
        numericInput("maxValue", "Maximum_value",10)
      })
      
      output$slider <- renderUI({
        sliderInput("inSlider", "Slider", min=input$minValue, 
                    max=input$maxValue,step = .1,
                    value=(input$maxValue+input$minValue)/2)
      })
      input_width <- reactive({input$inSlider})
    }
    
    #########################################################################
    # CREATE DYNAMIC NUMBER OF TABS
    # Get the climate data objects
    climate_data_objs = .self$get_climate_data_objects()
    obj_names <- names(climate_data_objs)
    
    #########################################################################
    # DATA SET TABS
    n1 <- length(obj_names)
    output$tabs1 <- renderUI({
      Tabs1 <- lapply(1:n1,function(i){
        tabs1_name <- paste("data_set:",obj_names[i])
        tabs2_id <- paste0("tabs2",i)
        tabPanel(tabs1_name,uiOutput(tabs2_id))
      })
      # Convert the list to a tagList - this is necessary for the 
      # list of items to display properly.
      do.call(tabsetPanel,Tabs1)
    })
    
    #########################################################################
    # Get each "data_obj" within "climate_data_objs"
    for(i000 in c(1:length(climate_data_objs))){
      # Need local so that each item gets its own number. Without it, 
      # the value of i in the renderPlot() will be the same across all 
      # instances, because of when the expression is evaluated.
      local({
        my_i000 <- i000
        data_obj <- climate_data_objs[[my_i000]]
        obj_name <- obj_names[[my_i000]]
        
        # Get each "curr_data" within "data_obj"
        data_list <- list()
        # Name of station_id column
        station_id_col = data_obj$getvname(station_label)
        # Get the different stations_id
        station_ids <- as.matrix(unique(data_obj$get_data()[station_id_col]))
        
        # Get date_time_period ("daily","subdaily",etc.)
        data_time_period = data_obj$data_time_period
        # Get the data frame for analysis
        curr_data_list = data_obj$get_data_for_analysis(data_list)
        
        #####################################################################
        # STATION_ID TABS
        n2 <- length(curr_data_list)
        tabs2_id <- paste0("tabs2",my_i000)
        output[[tabs2_id]] <- renderUI({
          Tabs2 <- lapply(1:n2,function(i){
            tabs2_name <- paste("station ID:",station_ids[i])
            tabs3_id <- paste0("tabs3",tabs2_id,i)
            tabPanel(tabs2_name,uiOutput(tabs3_id))
          })
          do.call(tabsetPanel,Tabs2)
        })
        
        # loop for computing 
        for(i00  in c(1:length(curr_data_list))){
          local({
            my_i00 <- i00
            curr_data <- curr_data_list[[my_i00]]
            if(data_time_period!="subdaily"){
              date_col = data_obj$getvname(date_label)
            }else{
              date_col = data_obj$getvname(date_time_label)
            }
            
            # Begin and end dates
            first.date <- curr_data[[date_col]][1]
            last.date <- curr_data[[date_col]][nrow(curr_data)]
            tperiod <- paste(first.date,"-",last.date, sep="")
            
            # Station id
            station_ids <- unique(curr_data[[station_id_col]])
            station_id <- station_ids[which(!is.na(station_ids))]
            
            #################################################################  
            # VARIABLE TABS
            # Get the data of each variable
            var_labels <- .self$get_var_labels(data_obj)   
            #z1 <- .self$get_zooObj(data_obj,curr_data)
            
            n3 <- length(var_labels)
            tabs3_id <- paste0("tabs3",tabs2_id,my_i00)
            output[[tabs3_id]] <- renderUI({
              Tabs3 <- lapply(1:n3,function(i){
                tabs3_name <- paste0(var_labels[[i]])
                plotname1 <- paste(tabs3_id,"plot",i,my_i00,sep="")
                tabPanel(tabs3_name, uiOutput(plotname1))
              })
              do.call(tabsetPanel,Tabs3)
            })
            
            #################################################################
            # SUBPLOTS (for subdaily)
            for (i0 in c(1:length(var_labels))){
              local ({
                my_i0 <- i0
                var_label <- as.character(var_labels[my_i0])
                n <- length(k[[my_i000]][[my_i00]][[my_i0]])
                plotname1 <- paste(tabs3_id,"plot",my_i0,my_i00,sep="")
                
                output[[plotname1]] <-renderUI({
                  plot_output_list <- lapply(1:n, function(i) {
                    plotname <- paste(tabs3_id,"plot",i,my_i0,my_i00,sep="")
                    graphOutput(plotname)
                  })
                  do.call(tagList, plot_output_list)
                })
                
                for (i in 1:n){
                  local({
                    my_i <- i
                    plotname <- paste(tabs3_id,"plot",my_i,my_i0,my_i00,sep="")
                    k2 <- k[[my_i000]][[my_i00]][[my_i0]][[my_i]][[1]]
                    
                    #########################################################
                    # PLOT PART (1/2)
                    # Create the plots
                    if (selected_plot=="Timeseries"){
                      output[[plotname]] <- renderDygraph({k2})
                    }
                    if (selected_plot=="Histogram"){
                      k2 %>% layer_histograms(width=input_width) %>%
                        bind_shiny(plotname,plotname1)
                    }
                  })
                }
              })
            }
          })
        }
      })
    }
  }
  app <- shinyApp(ui,server)
  runApp(app)
})