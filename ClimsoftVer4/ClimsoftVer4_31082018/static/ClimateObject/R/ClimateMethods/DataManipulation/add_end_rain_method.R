#==================================================================================================
# END OF RAINS
#' @title Computational of end of the rain with water balance definition
#' @name add_end_rain
#' @author Danny, Frederic and Fanuel 2015 (AMI)

#' @description \code{compute.end_rain} 
#' compute end of the rains given climate object
#' 
#' @param data_list list. 
#' 
#' @param end.rains type character. Type of end of rains to be computed. It is yearly summary. 
#  
#' @examples
#' ClimateObj <- climate( data_tables = list( data ), date_formats = list( "%m/%d/%Y" ) )
#' Default dateformats: "%Y/%m/%d"
#' # where "data" is a data.frame containing the desired data to be computed.
#' climateObj$add_end_rain()
#' @return return end of the rain 
#' 


climate$methods(add_end_rain = function(data_list=list(), earliest_day = 228, water_balance_col_name = "Water Balance", 
                                        col_name = "End of the rains", capacity_max = 100, evaporation = 5,
                                        replace=FALSE) {
  
  
  # We don't restrict the years when calculating end of rain. We calculate for the
  # whole data set. When displaying we can show a subset of the data if needed.
  # year has been removed as an argument.
  
  data_list=add_to_data_info_required_variable_list(data_list, list(rain_label))
  data_list=add_to_data_info_time_period(data_list, daily_label)
  climate_data_objs = get_climate_data_objects(data_list)
  
  
  for(data_obj in climate_data_objs) {
    
    end_rain = list()
    
    summary_obj <- get_summary_name(yearly_label, data_obj)
    
    continue = TRUE
    
    if(col_name %in% names(summary_obj$get_data()) && !replace) {
      message(paste("A column named", col_name, "already exists. The column will not be replaced.
                    To replace to column, re run this function and specify replace = TRUE."))
      continue = FALSE
    }
    
    if(col_name %in% names(summary_obj$get_data()) && replace) {
      message(paste("A column named", col_name, "already exists. The column will replaced 
                    in the data."))
    }
    
    # 3. check if definition already exists, then do not add
    # need to more carefully define evaporation
    curr_definition = list(earliest_day = earliest_day, capacity_max = capacity_max, 
                           evaporation = evaporation)
    
    if( continue && summary_obj$is_definition(rain_label,end_of_label,curr_definition)) {
      message("A column with this defintion already exists in the data.
              The column will not be added again.")
      continue = FALSE
    }
    
    if(continue) {
      
      # rain is required so we don't need to check if it's present
      rain_col = data_obj$getvname(rain_label)
      
      # Complete dates needed for calculations
      data_obj$missing_dates_check()
      
      
      #if doy or year/dos season is not in the data frame, create it.
      if( !( data_obj$is_present(dos_label) && data_obj$is_present(season_label) ) ) {
        data_obj$add_doy_col()
      }
      
      season_col = data_obj$getvname(season_label)
      dos_col = data_obj$getvname(dos_label)
      
      if( !(data_obj$is_present(waterbalance_label)) ) {
        if(missing(capacity_max)) {
          data_obj$add_water_balance_col(col_name=water_balance_col_name,evaporation=evaporation)
        }
        else { data_obj$add_water_balance_col(water_balance_col_name,capacity_max,evaporation) }
      }
      # Don't need to append to variables. This is done by add_waterbalance_col.
      
      waterbalance_col = data_obj$getvname(waterbalance_label)
      
      # get the data with empty list so we do not subset the data here
      curr_data_list = data_obj$get_data_for_analysis(list())
      
      for( curr_data in curr_data_list ) {
        
        # Split curr_data into single data frames for each year
        # It returns a list of data.frames, split by year 
        # This is much faster than subsetting each time
        # Split is not always appropriate but it is in this case
        seasons_split <- split(curr_data, list(as.factor(curr_data[[season_col]])))
        
        i = 1
        for (single_season in  seasons_split)  {
          
          single_season <- single_season[single_season[[dos_col]] >= earliest_day,c(dos_col,waterbalance_col, season_col)]
          
          # default value if end of season not found
          end_rain[i] = NA
          
          # subsetting above may give an empty data frame
          if(nrow(single_season)==0) next
          
          for( j in 1:nrow(single_season) ) {
            if( !is.na(single_season[[waterbalance_col]][[j]]) 
                && single_season[[waterbalance_col]][[j]] == 0 ) {  
              end_rain[i] = single_season[[dos_col]][[j]]
              break
            }
          }
          i = i + 1  
        }
        names(end_rain) <- names(seasons_split)
      }
      
      #   if( plot == TRUE ){
      #     plot( year, endday, type = "b", col = "blue", ylab = "End of the rain",
      #           xlab = "Year", main = main)
      #   }
      summary_obj$append_column_to_data(end_rain, col_name)
      label = summary_obj$get_summary_label(rain_label, end_of_label, curr_definition)
      summary_obj$append_to_variables(label,col_name)
    }
    }
  }
)
