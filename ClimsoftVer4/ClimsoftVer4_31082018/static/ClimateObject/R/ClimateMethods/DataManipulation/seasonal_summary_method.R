#==================================================================================================
# SEASONAL SUMMARIES
#' @title compute seasonal summaries.
#' @name seasonal_summary
#' @author Frederic, Fanuel and Steve 2015 (AMI)

#' @description \code{seasonal.summary} 
#' Adds  column(s) of sesonal summaries (e.g rain totals, number of rain days, and longest dry spell)
#'  given climate object.
#' 
#' @param month_start A vector of months indicating when the calculation of seasonal summary should be started,
#' the default is January. 
#' @param number_month Number of months indicating how many months will be considered in the 
#' calculation of seasonal summary.The default is three months i.e Jan,Feb and Mar.
#' @param threshold    A value over which a day is considered rainy.
#' @param func         A summary function e.g sum, mean, max, median.
#' @param col_names    A list of vectors of names of columns to be appended to the yearly summary
#' @param col_name     Name of the spell length column.
#' @param  season_rain_total A logical indicating whether rain total column should be appended to
#'the yearly summary object.
#' @param  season_rain_days A logical indicating whether a column of rain days should be appended to
#'the yearly summary object.
#' @param  longest_dry_spell A logical indicating whether a column of longest dry spell in a given 
#' period should be appended to the yearly summary object.
#' @param replace  A logical indicating whether the column values in yearly summary object should be 
#' replaced.
#' @param  na.rm A logical indicating whether missing values should be removed.
#' @param  
#' @examples
#' ClimateObj <- climate( data_tables = list(dataframe=dataframe), date_formats = list( "%m/%d/%Y" ) )
#' Default dateformats: "%Y/%m/%d"
#' # where "data" is a data.frame containing the desired data to be computed.
#' climateObj$seasonal_summary();View(climateObj$used_data_objects$dataframe$data)
#' @return return columns of seasonal summaries.
#' 

climate$methods(seasonal_summary = function(data_list = list(), month_start, number_month = 3, threshold = 0.85, func = sum,
                                            col_names = list(c("Rain Total","Number Raindays", "Dry Spell Max")),col_name = "spell length", season_rain_total=TRUE, season_rain_days=FALSE,
                                           longest_dry_spell = FALSE, na.rm = FALSE, replace = FALSE){  
  # rain required
  data_list = add_to_data_info_required_variable_list(data_list, list(rain_label))
  # date time period is "daily"
  data_list = add_to_data_info_time_period(data_list, daily_label)
  # a list of climate data objects
  climate_data_objs = get_climate_data_objects(data_list)
  
  for(data_obj in climate_data_objs) {
    
    curr_threshold = data_obj$get_meta(threshold_label,threshold)
    
    rain_col  = data_obj$getvname(rain_label) 
    
    if( !(data_obj$is_present(spell_length_label)) ) {
      data_obj$add_spell_length_col(col_name=col_name, threshold=threshold)
    }
    spell_length_col = data_obj$getvname(spell_length_label)
    
    # Must add month column if not present
    if( !( data_obj$is_present(month_label)) ) {
      data_obj$add_year_month_day_cols()
    }
    
    month_col = data_obj$getvname(month_label)
    
    # must add seasonal column to the data
    if ( !(data_obj$is_present(season_label))) {
      data_obj$add_doy_col()
    }
    season_col = data_obj$getvname(season_label) 
    
    if(missing(month_start)){
      curr_season_start_day = data_obj$get_meta(season_start_day_label)
      year=1952
      date = doy_as_date(curr_season_start_day, year) 
      month_start = month(date)
    }
    col_name0=col_names
    month_start0=c()
    for (period in 1:length(month_start)){
          
      if (is.character(month_start[period])){
        if (!month_start[period] %in% c(month.abb, month.name,tolower(c(month.abb, month.name)))){
          stop("Enter the upper or lower case of English names for the months of the year; e.g Jan,January,jan,january")
        }
        month_start0[period]= 1 + ((match(tolower(month_start[period]), tolower(c(month.abb, month.name))) - 1) %% 12)
      }else {
        month_start0[period] = month_start[period]
      }
      months = 1+(((month_start0[period]:(month_start0[period]+number_month-1)) -1) %% 12)
      
      if (length(month_start) > length(col_names) && period==1){
        col_names = list(paste(col_names[[1]], month_start0[1], sep = "_"))
      }
      if (length(month_start) > length(col_names) && period>1){
        col_names = append(col_names, list(paste(col_name0[[1]], month_start0[period], sep = "_")))
      }
      
      summary_obj <- get_summary_name(yearly_label, data_obj)
      
      continue = TRUE
      
      curr_definition = list(month_start = month_start[period], number_month = number_month, threshold = threshold)
      labs = c(seasonal_total_label , seasonal_raindays_label, spell_length_label)
      conditions =c((season_rain_total && !season_rain_days && !longest_dry_spell)|(season_rain_total & season_rain_days & longest_dry_spell)|(season_rain_total & season_rain_days)|(season_rain_total & longest_dry_spell), 
                    (season_rain_days && !season_rain_total && !longest_dry_spell)|(season_rain_days & season_rain_total & longest_dry_spell)|(season_rain_days & season_rain_total)|(season_rain_days & longest_dry_spell),
                    (longest_dry_spell && !season_rain_days && !season_rain_total )|(season_rain_days & season_rain_total & longest_dry_spell)|(longest_dry_spell & season_rain_total)|(longest_dry_spell & season_rain_days ))
      for(i in 1:length(col_names[[period]])){
        if(conditions[i]){
          if(col_names[[period]][i] %in% names(summary_obj$get_data()) && !replace) {
            message(paste("A column named", col_names[[period]][i], "already exists. The column will not be replaced.
                          To replace to column, re run this function and specify replace = TRUE."))
            continue = FALSE
          }
          if(col_names[[period]][i] %in% names(summary_obj$get_data()) && replace){
            message(paste("A column named", col_names[[period]][i], "already exists. The column will be replaced 
                          in the data."))
          }
          if(labs[i] ==spell_length_label ){
            if( continue && summary_obj$is_definition(spell_length_col,labs[i],curr_definition)) {
              message("A column with this defintion already exists in the data.
                    The column will not be added again.")
              continue = FALSE
            }
          
          }else{
            if( continue && summary_obj$is_definition(rain_label,labs[i],curr_definition)) {
              message("A column with this defintion already exists in the data.
                    The column will not be added again.")
              continue = FALSE
            }
          }
        }
      }
      
      if(continue) {
        
        curr_data_list = data_obj$get_data_for_analysis(data_list)
        
        for( curr_data in curr_data_list ) {
          month_tot=rep(NA,length(unique(curr_data[[season_col]])))
          dry_spells=raindays=month_tot
          
          rain.season = curr_data[which(curr_data[[month_col]] %in% months),c(season_col,rain_col,spell_length_col)]
          
          for (yr in unique(curr_data[[season_col]])) {
            if(conditions[1]){
              month_tot[yr-min(unique(curr_data[[season_col]])-1)]=func(rain.season[rain.season[,season_col]==yr,rain_col], na.rm = na.rm)
            }
            if(conditions[2]){
              raindays[yr-min(unique(curr_data[[season_col]])-1)]=sum(rain.season[rain.season[,season_col]==yr,rain_col]>threshold, na.rm = na.rm)
            }
            if(conditions[3]){
              dry_spells[yr-min(unique(curr_data[[season_col]])-1)]=max(rain.season[rain.season[,season_col]==yr,spell_length_col], na.rm = na.rm)
            }
          }
          
          result = list(month_tot, raindays, dry_spells)        
        }
                
        for (j in 1:length(col_names[[period]])){
          if (conditions[j]){
            if(labs[j] == spell_length_label ){
              summary_obj$append_column_to_data(result[[j]], col_names[[period]][j])
              label = summary_obj$get_summary_label(spell_length_label, labs[j],curr_definition)
              summary_obj$append_to_variables(label, col_names[[period]][j])
            }
            else{
              summary_obj$append_column_to_data(result[[j]], col_names[[period]][j])
              label = summary_obj$get_summary_label(rain_label, labs[j],curr_definition)
              summary_obj$append_to_variables(label, col_names[[period]][j])
            }
          }
        }        
      }
    }
  }
}
)
#==================TO DO=======================================================================================
# Restrict daily values between a given limit.
# To consider days of the season instead of the months when specifying the season over which to calculate the summary.

