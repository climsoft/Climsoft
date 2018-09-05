#==================================================================================================================
# DISPLAY DAY OF THE YEAR 
#' @title Get the table of day of the year
#' @name display_doy
#' @author Frederic Ntirenganya 2015 (AMI)
#' 
#' @description \code{get.table_doy }
#' Display day of the year in a table  
#'  
#' @param data_list list. 
#' 
#' @param variable.type character. Type of variable to be displayed.It is for each year. 
#  
#' @examples
#' ClimateObj <- climate( data_table = list( data ), date_formats = list( "%m/%d/%Y" ) )
#' Default dateformats: "%Y/%m/%d"
#' # where "data" is a data.frame containing the desired variable to be displayed.
#' climateObj$display_doy()
#' @return It returns  a table

climate$methods(display_doy = function(data_list = list(), months_list = month.abb, single_year, day_display = "Day", file="DOY.doc",save_table = FALSE,
                                       row.names = FALSE, width=8.5, height=11, font.size=6, title="DOY table", font.size2=10, NA.string=" "){
  
  # data time period.
  data_list = add_to_data_info_time_period( data_list, daily_label )
  #Get the data objects
  climate_data_objs = get_climate_data_objects( data_list )
    
  for( data_obj in climate_data_objs ) {

    # must add these columns if not present for displaying
    if( !(data_obj$is_present( year_label ) && data_obj$is_present( month_label ) && data_obj$is_present( day_label )) ) {
      data_obj$add_year_month_day_cols()
    }
    year_col = data_obj$getvname( year_label )
    month_col = data_obj$getvname( month_label )
    day_col = data_obj$getvname( day_label )
    # must add doy_col if not present
    if( !(data_obj$is_present( doy_label )) ) {
      data_obj$add_doy_col()
    }
    doy_col = data_obj$getvname( doy_label )
    
    curr_data_list = data_obj$get_data_for_analysis( data_list )
    
    for( curr_data in curr_data_list ) {
      # Split curr_data into single data frames for each year
      # It returns a list of data.frames, splited by year 
      # This is much faster (6x faster when checked) than subsetting
      # Split is not always appropriate but it is in this case
      years_split <- split( curr_data, list( as.factor( curr_data[[year_col]] ) ) )
      # loop through the splited data frames 
      for ( single_year in years_split ) {
        # produce table with data
        table <- dcast( single_year, single_year[[ day_col ]] ~ single_year[[ month_col ]], value.var = doy_col)
        # Added day_display and months_list as extra arguments so it is more flexible
        end = length( colnames( table ) )
        names( table )[ 1 ] <- day_display
        colnames( table )[2:end] <- months_list[1:end-1]
      }
    }
    #Always print table
    print( table, row.names = row.names )
    #Some one might want this file. 
    if(save_table==TRUE){
      #set output file
      rtf<-RTF(file=file, width=width, height=height, font.size=font.size)
      #add title
      addHeader(rtf, title=title, font.size=font.size2)
      #add table
      addTable(rtf, table, NA.string=NA.string, row.names=row.names)
      #save output file
      done(rtf)
      
    }
    
  }  
}
)
