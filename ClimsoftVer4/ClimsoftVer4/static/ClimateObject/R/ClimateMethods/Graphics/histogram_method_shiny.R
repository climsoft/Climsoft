##############################################################################
# HISTOGRAM - SHINY
#' @title Get Histograms from a climObject through shiny
#' @name histogram_shiny
#' @author Rafael Posada, August 2015 (SASSCAL/DWD)
#' @description 
#' Allows plotting the data in a histogram plot. It does not require 
#' any input since it takes all the information from the Climate Object
#'  
#' @return Returns a list of plots. This list can be then used by 
#' \code{graphics_frontend_shiny} to plot the histograms into the shiny 
#' interface.
#' 
#' 
climate$methods(histogram_shiny = function(){
  ############################################################################
  # Required packages
  library(ggvis)
  
  ###########################################################################
  # Create empty list where the plots will be saved 
  k <- list()
  print("Creating histograms...")
  
  ###########################################################################
  # Get the climate data Objects
  data_list <- list()
  climate_data_objs = .self$get_climate_data_objects(data_list)
  
  for(i000 in c(1:length(climate_data_objs))) {
    data_obj <- climate_data_objs[[i000]]
    data_name = data_obj$get_meta(data_name_label)
    k[[i000]] <- data_name
    
    ######################################################################
    # GET COMMON VARIABLES
    # Name of station_id column
    station_id_col = data_obj$getvname(station_label)
    
    # Get date_time_period ("daily","subdaily",etc.)
    data_time_period = data_obj$data_time_period
    
    # Get the data frame for analysis
    curr_data_list = data_obj$get_data_for_analysis(data_list)
    
    # Get var labels
    var_labels <- .self$get_var_labels(data_obj)
    
    #########################################################################
    # Get the station id for each curr_data available
    for(i00 in c(1:length(curr_data_list))) {
      k[[i000]][[i00]] <- paste0("curr_data",i00)
      curr_data <- curr_data_list[[i00]]
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
      
      ######################################################################
      # Get the data of each variable
      for (i0 in c(1:length(var_labels))){
        k[[i000]][[i00]][[i0]] <- var_labels[i0]
        
        # Get the variable 
        var_col = data_obj$getvname(as.character(var_labels[i0]))
        y <- curr_data[[var_col]]
        x <- curr_data[[date_col]]
        z5 <- .self$get_zooObj(x,y,data_time_period)
        n <- length(z5[1,])
        
        #####################################################################
        # Define the options of the plot (e.g. color)
        if (var_labels[[i0]]=="rain"){
          colplot <- "blue"
          }else{
          colplot <- "red"
        }
        
        #####################################################################
        # Create plots
        for (i in 1:n){
          tit <- colnames(z5)[i]
          data.hist.prev <- coredata(z5[,i])
          data.hist <- data.hist.prev[!is.na(data.hist.prev)]
          mtc <-  as.data.frame(data.hist)
          k[[i000]][[i00]][[i0]][[i]] <- list(
            mtc %>% 
              ggvis(~data.hist,fill:=colplot) %>%
              #layer_histograms() %>%
              add_axis("x",title=as.character(var_labels[i0])) %>%
              .self$add_title(x_lab = "", title=tit) %>%
              add_axis("y",title_offset = 50) %>%
              set_options(renderer = "canvas")
          )
        }
      }
    }
  }
  print("Histograms created!")
  return(k)
})
##############################################################################
# Funtion to add a title to the "histogram
climate$methods(add_title=function(vis, ..., x_lab = "X units", 
                                   title = "Plot Title") 
{
  add_axis(vis, "x", title = x_lab) %>% 
    add_axis("x", orient = "top", ticks = 0, title = title,
             properties = axis_props(
               axis = list(stroke = "white"),
               labels = list(fontSize = 0)
             ), ...)
})
