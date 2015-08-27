#==================================================================================================================
# DISPLAY DAILY
#' @title Get the tables of daily data
#' @name Display_daily
#' @author Frederic Ntirenganya 2015 (AMI)
#' 
#' @description \code{Display daily data in tables }
#' Display daily data in tables for any variable 
#'  
#' @param data_list list. 
#' 
#' @param variable.type character. Type of variable to be displayed.It is for each year. 
#  
#' @examples
#' ClimateObj <- climate( data_tables = list( data ), date_formats = list( "%m/%d/%Y" ) )
#' Default dateformats: "%Y/%m/%d"
#' # where "data" is a data.frame containing the desired variable to be displayed.
#' climateObj$display_daily()
#' @return It returns tables list

climate$methods(display_daily = function(data_list = list(), print_tables = FALSE, row.names = FALSE, na.rm = TRUE, variable = rain_label, threshold = 0.85, months_list = month.abb, day_display = "Day"){
    
  #required variable
  data_list = add_to_data_info_required_variable_list(data_list, list(variable))
  # data time period is daily
  data_list = add_to_data_info_time_period( data_list, daily_label )
  rettables=list()
  climate_data_objs = get_climate_data_objects( data_list )
  
  for( data_obj in climate_data_objs ) {
    
    curr_threshold = data_obj$get_meta(threshold_label,threshold)
    
    #get required variable name
    interest_var = data_obj$getvname( variable )
    
    # must add these columns if not present for displaying
    if( !(data_obj$is_present( year_label ) && data_obj$is_present( month_label ) && data_obj$is_present( day_label )) ) {
      data_obj$add_year_month_day_cols()
    }
    year_col = data_obj$getvname( year_label )
    month_col = data_obj$getvname( month_label )
    day_col = data_obj$getvname( day_label )
    
    # access data for analysis
    curr_data_list = data_obj$get_data_for_analysis( data_list )
    
    for( curr_data in curr_data_list ) {
      # initialize tables as a list
      tables = list()
      tables_2 = list()
      tables_12 = list()
      # Split curr_data into single data frames for each year
      # It returns a list of data.frames, splited by year 
      # This is much faster (6x faster when checked) than subsetting
      # Split is not always appropriate but it is in this case
      years_split <- split( curr_data, list( as.factor( curr_data[[year_col]] ) ) )
      # counter used in the loop
      i = 1
      j = 1
      k = 1
      # loop through the splited data frames 
      for ( single_year in years_split ) {
        # produce table with data
        tables[[i]] <- dcast( single_year, single_year[[ day_col ]] ~ single_year[[ month_col ]], value.var = interest_var)
        # Added day_display and months_list as extra arguments so it is more flexible
        end = length( colnames( tables[[i]] ) )
        names( tables[[i]] )[ 1 ] <- day_display
        colnames( tables[[i]] )[2:end] <- months_list[1:end-1]
        
        #create quick function to count number of obs larger than a certain value which can be run in an apply
        largerthan <- function(x,val){
          length(na.omit(x[x>val]))
        }
        #produce second table with summary stats
        tables_2[[j]] <- rbind(colSums(tables[[j]][,-1], na.rm = na.rm), apply(tables[[j]][,-1],2, max, na.rm = na.rm), apply(tables[[j]][,-1],2,largerthan, val = curr_threshold))
        # add dimnames
        tables_2[[j]] <- cbind(c("Total","Maximum","Number>0.85"), tables_2[[j]])
        # Making dataframe for second table
        tables_2[[j]] <- data.frame(tables_2[[j]])
        #add dimnames for the first column.
        colnames(tables_2[[j]])[1] <- ("Day")
        # merge the tables
        tables_12[[k]] <- rbind(tables[[i]], tables_2[[j]])
        i = i + 1
        j = j + 1 
        k = k + 1
                
      }
      # The names of years_split is the list of years as strings.
      # These are better labels than numbers so they can be identified better
      names( tables_12 ) <- names( years_split )
      rettables[[data_obj$get_station_data(curr_data, station_label)]] = tables_12  
    }
    # Only print if requested
    if (print_tables) {print( tables_12, row.names = row.names) }
        
    # Always return the tables list because If we don't return and don't print then the method does nothing!    
    return( tables_12 )
    }  
}
)
