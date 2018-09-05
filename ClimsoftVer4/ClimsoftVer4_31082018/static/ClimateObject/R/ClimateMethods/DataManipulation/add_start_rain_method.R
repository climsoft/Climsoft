#==================================================================================================
# START OF RAINS
#' @title Computational of start of the rain for various definitions
#' @name add_start_rain
#' @author Danny and ANdree 2015 (AMI)

#' @description \code{compute.start_rain} 
#' compute start of the rains given climate object
#' 
#' @param data_list list. 
#' 
#' @param Strt.Rains type character. Type of start of rains to be computed. It is yearly summary. 
#  
#' @examples
#' ClimateObj <- climate(data_tables = list( data ), date_formats = list("%m/%d/%Y"))
#' Default dateformats: "%Y/%m/%d"
#' # where "data" is a data.frame containing the desired data to be computed.
#' climateObj$add_start_rain()
#' @return return start of the rain for current definition 
#' 


climate$methods(add_start_rain = function(data_list=list(), earliest_day=92, total_days=2, rain_total=20, dry_length=30,
                                          dry_days=10, dry_spell_condition=FALSE, threshold = 0.85, col_name = "Start of Rain",
                                          replace=FALSE) {
  
  data_list=add_to_data_info_required_variable_list(data_list, list(rain_label))
  data_list=add_to_data_info_time_period(data_list, daily_label)
  climate_data_objs = get_climate_data_objects(data_list)
  
  for(data_obj in climate_data_objs) {
    
    summary_obj <- get_summary_name(yearly_label, data_obj)
    
    # use get_meta to determine the correct threshold value to use
    threshold = data_obj$get_meta_new(threshold_label,missing(threshold),threshold)
    
    # to do
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
    curr_definition = list(earliest_day = earliest_day, total_days = total_days, 
                           rain_total = rain_total, dry_spell_condition = dry_spell_condition, 
                           threshold = threshold)
    
    if( continue && summary_obj$is_definition(rain_label,start_of_label,curr_definition)) {
      message("A column with this defintion already exists in the data.
              The column will not be added again.")
      continue = FALSE
    }
    
    if(continue) {
      
      #if doy or year/dos is not in the data frame, create it.
      if( !( data_obj$is_present(dos_label) && data_obj$is_present(season_label) ) ) {
        data_obj$add_doy_col()
      }
      
      # get names of columns in the data
      rain_col = data_obj$variables[[ rain_label ]]
      dos_col = data_obj$variables[[ dos_label ]]
      season_col = data_obj$variables[[ season_label ]]
      
      # column to store day of year of start of the rain
      start_of_rain_col <- list()
      
      # Use an empty data_list here because we want to calculate start of rains
      # for the whole data set.
      curr_data_list = data_obj$get_data_for_analysis(data_info = list())
      
      # adding start of rain column
      for(curr_data in curr_data_list ) {
        
        # split the data by year to do calculations
        seasons_split <- split(curr_data[,c(dos_col,rain_col)], list(as.factor(curr_data[[season_col]])))
        
        
        j = 1 
        for( single_season in seasons_split ) {
          
          # initialize to NA incase conditions are never met
          start_of_rain_col[j] = NA
          
          # initialize current earliest day
          curr_earliest_day = earliest_day
          
          # if dry spell required use the simple sum_check to get start of the rain
          if(!dry_spell_condition) {
            start_of_rain_col[j] = sum_check(single_season, curr_earliest_day, total_days, rain_total)[1]
          }
          
          else {
            # If sum and dry spell conditions are required
            
            # indicates whether both conditions have been met and 
            # start of rain has been found
            # initialize to FALSE
            found = FALSE
            
            num_rows = nrow(single_season)
            
            # while start of the rain has not been found and our earliest day to check is not too
            # close to the end of year we continue looking for the start of the rain
            # if the dry_length is greater than the remaining number of rows
            # we will not be able to check for dry spells so we cannot get a start of the rain
            # NA will be returned
            if(data_obj$meta_data$data_name=="chief") {
              print(dry_length)
              print(num_rows)
              print(curr_earliest_day)
              
            }
            while( !found && sum(single_season[[1]]==curr_earliest_day)>0 && dry_length <= num_rows -  which(single_season[[1]]==curr_earliest_day) ) {
              # get the first day after earliest_day which is over rain_total
              day = sum_check(single_season, curr_earliest_day, total_days, rain_total)[1]
              
              # if the dry_length is greater than the remaining number of rows
              # we can no longer check for dry spells so end the loop
              # also if day is missing, end the loop.
              # NA will be returned
              if( is.na(day) || dry_length > num_rows - which(single_season[[1]]==day) ) break
              
              # start day to check for a dry spell is the day after the day found by sum_check
              start_row = which(single_season[[1]]==day+1)
              
              # if there is no dry spell we have found the start of the rain
              # found = TRUE will mean the loop does not run again
              if( !dry_spell_check(single_season[start_row:num_rows, 2], dry_length, dry_days, threshold) ) {
                start_of_rain_col[j] = day
                found = TRUE
              }
              else {
                # in the worst case there was a dry spell of length dry_days start after day.
                # The next check should begin after this potential dry spell.
                # if this day is beyond the end of the year, exit the loop to return NA.
                if(is.na(which(single_season[[1]]==day + dry_length))) break
                else curr_earliest_day = day + dry_length
              }
            }
          }
          j = j + 1
        }
      }
      # append this column to the yearly summary for each data object
      summary_obj$append_column_to_data(start_of_rain_col, col_name)
      label = summary_obj$get_summary_label(rain_label, start_of_label, curr_definition)
      summary_obj$append_to_variables(label,col_name)
      
    }  
    }
  
  }
)
