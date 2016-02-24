#############################################################################
# TIMESERIES -SHINY
#' @title Get Timeseries from a climObject through shiny
#' @name timeseries_shiny
#' @author Rafael Posada, August 2015 (SASSCAL/DWD)
#' @description 
#' Allows plotting the data in a timeseries plot. It does not require 
#' any input since it takes all the information from the Climate Object
#'  
#' @return Returns a list of plots. This list can be then used by 
#' \code{graphics_frontend_shiny} to plot the timeseries into the shiny 
#' interface.
#' 
#
climate$methods(timeseries_shiny = function(){
  ###########################################################################
  # Required packages
  library(dygraphs)
  
  ###########################################################################
  # Create empty list where the plots will be saved 
  k <- list()
  print("Creating timeseries...")
  
  ###########################################################################
  # Get the climate data Objects
  data_list <- list()
  climate_data_objs = .self$get_climate_data_objects(data_list)
  
  for(i000 in c(1:length(climate_data_objs))) {
    data_obj <- climate_data_objs[[i000]]
    data_name = data_obj$get_meta(data_name_label)
    k[[i000]] <- data_name
    
    #########################################################################
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
    for(i00 in c(1:length(curr_data_list))){
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
          fg <- F
          stp <- T
        }else{
          colplot <- "red"
          fg <- FALSE
          stp <- F
        }
        
        #####################################################################
        # Create plots
        for (i in 1:n){
          k[[i000]][[i00]][[i0]][[i]] <- list(
            dygraph(z5[,i],main = colnames(z5)[i]) %>%
            dyOptions(stepPlot =stp, 
                      fillGraph=fg,
                      colors=colplot,
                      drawGrid =T,
                      useDataTimezone =TRUE) %>%
            dyRangeSelector(height = 20) 
          )
        }
      }
    }
  }
  print("Timeseries created!")
  return(k)
})