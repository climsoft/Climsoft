#==================================================================================================
# change format of the date
#' @title Get the format of date as day+month
#' @name day_month
#' @author Frederic Ntirenganya 2015 (AMI)
#' 
#' @description \code{change format of date to be day+month }
#' create a date column in the format day-month
#' 
#' @param data_list() list 
#' 
#'  @examples
#'  climateObj <- climate (data_tables = list (data), date_formats = list( "%m/%d/%Y" )) 
#'  Default dateformats: "%Y/%m/%d"
#' # where "data" is a data.frame containing the desired data to be computed.
#' 
#' @return Adds a day-month column on the data
#' 


climate$methods(day_month = function(data_list = list(), time_period = daily_label, col_name = "Day_Month", month_format = "%m", required_format = "%d-%b"){
  
  #this method Changes the format of date so that the date appear in the format day+month (i.e. "17 Apr" rather than "108")
  #given the date column.
  # it takes a specific date of the year and create a column of the date in the format day-month.
  #==============================================================================================
  # data time period 
  data_list = add_to_data_info_time_period(data_list, time_period)
  # a list of climate data objects
  climate_data_objs = get_climate_data_objects(data_list)
  
  for (data_obj in climate_data_objs){
    
    date_col = data_obj$getvname(date_label)
   
    curr_data_list = data_obj$get_data_for_analysis(data_list)
    for (curr_data in curr_data_list){
      #Initialise the vector which will contain the result
      day_month_col <- c()
     day_month_col <- format( strptime(curr_data[[ date_col ]], format="%Y-%m-%d"), format = required_format)          
    }
  }
  data_obj$append_column_to_data(day_month_col, col_name)
  data_obj$append_to_variables(dm_label, col_name)   
}

)
