##############################################################################
# GET THE NAME OF THE VARIABLES
#' @title Retrieve variable names from data_object
#' @name get_var_labels
#' @author Rafael Posada August, 2015 (SASSCAL/DWD)
#' @description 
#' Allows identification of the name of the variables that are actually 
#' available in the given data_obj
#'  
#' @return Returns the names of variables in a list object
#' 
climate$methods(get_var_labels = function(data_obj){
  
  #####################################################################
  # GET VARIABLE TO PLOT
  data_name = data_obj$get_meta(data_name_label)   
  # Rain
  var_label=list()
  if (data_obj$is_present(rain_label)){
    var_label[[rain_label]]=rain_label
  }
  # Minimum Temperature
  if (data_obj$is_present(temp_min_label)) {
    var_label[[temp_min_label]]=temp_min_label
  }
  # Maximum Temperature
  if (data_obj$is_present(temp_max_label)){
    var_label[[temp_max_label]]=temp_max_label
  }
  # Observed Temperature
  if (data_obj$is_present(temp_air_label)){
    var_label[[temp_air_label]]=temp_air_label
  }
  # Wind speed 
  if (data_obj$is_present(wind_speed_label)){
    var_label[[wind_speed_label]]=wind_speed_label
  }
  # Wind direction
  if (data_obj$is_present(wind_direction_label)) {
    var_label[[wind_direction_label]]=wind_direction_label
  }
  return(var_label)
})


##############################################################################
# GET ZOO OBJECT TO CREATE TIMESERIES & HISTOGRAMS
#' @title Creation of a zooObject for plotting
#' @name get_zooObj
#' @author Rafael Posada August, 2015 (SASSCAL/DWD)
#' @description 
#' It creates an output of class "zoo", which allows plotting timeseries
#' under the "dygraphs" package. It is also use to plot histograms.
#'  
#' @return Creates a zooObject
#' 
climate$methods(get_zooObj= function(x,y,data_time_period){
  #######################################################################
  require(zoo)
  # Make sure to use always the same time format:
  x <- as.POSIXct(as.character(x),tz="UTC")
  # Get the time period stamp of the dataset
  time_diff <- diff(x)
  # Count cases with the same time stamp
  time_stamp <- table(diff(x))
  
  # a) get the time difference units (minutes, hours, etc.)
  time_units <- units(time_diff)
  id <- which(time_stamp==max(time_stamp))
  time_interval <- names(time_stamp)[id]
  data_time_interval <- paste(time_interval,time_units)
  full <- seq.POSIXt(x[1],x[length(x)],by=data_time_interval)
  all.dates.frame <- data.frame(list(x=full))
  merged.data <- merge(all.dates.frame,data.frame(x,y),all=T)
  
  # Split the dataset if the time_interval is higher than 1 (meaning
  # that the timeseries is not a continuum)
  if (data_time_period=="subdaily"){
    if (as.numeric(time_interval) > 1){
      times <- sort(unique(strftime(merged.data$x,format="%H:%M:%S",
                                    tz="UTC")))
      dates <- unique(strftime(merged.data$x,format="%Y-%m-%d",
                               tz="UTC"))
      
      full.new <- as.Date(seq.POSIXt(x[1],x[length(x)],by="1 day"),
                          format = "%Y-%m-%d")
      all.dates.frame.new <- data.frame(list(x=full.new))
      merged.data.new <- data.frame(x=all.dates.frame.new$x)
      tmp1 <- merged.data
      for (i0 in c(1:length(times))){
        data00 <- subset(tmp1,
                         strftime(tmp1$x,
                                  format="%H:%M:%S",tz="UTC")==times[i0])
        data00$x <- as.Date(data00$x,"%Y-%m-%d",tz="UTC")
        colnames(data00)[2] <- times[i0]
        tmp2 <- merge(all.dates.frame.new,data00,all=T)
        merged.data.new <- cbind(merged.data.new,tmp2[,2])
        colnames(merged.data.new)[i0+1] <- times[i0]
      }
      merged.data <- merged.data.new
    }
  }
  z5 <- with(merged.data,zoo(merged.data[,c(2:ncol(merged.data))],
                             order.by=merged.data$x))
  return(z5)
})