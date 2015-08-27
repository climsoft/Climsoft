#=============================================================================
# Multiple Lines Plot
#' @title Plot Multiple lines 
#' @name plot_multiple_lines
#' @author Andree Nenkam and Frederic Ntirenganya AMI (2015)

#' @description \code{get.plot_multiple_lines} 
#' Plot multiple lines on the same plot given a climate object 
#' 
#' @param data_list list. 
#' 
#' 
#' @param variables list containing the title of the columns to be plotted on the same plot 
#  
#' @examples
#' data_obj = climate$new( data_tables = list(data = data), data_time_periods = list("yearly"))
#' #where "data" is a data.frame containing the desired data to be plotted.
#' data_obj$plot_multiple_lines( data_list = list(), variables = list( c( "May", "Jun", "Jul" )), type = c("h") )
#' @return Multiple lines plot
#' 



climate$methods(plot_multiple_lines = function(data_list=list(), variables, col = c("blue", "red", "green"), type = c("h", "h", "h"), lty= c(1,2,3), lty_points= c(1,2,3), ylabel="Observations", xlabel = "Year",lwd=c(2), 
                                      lwd_points=c(2,2,2), pch = c(2,20,4),bty = "o", main="Vertical Lines", time_period = yearly_label, legend.location = rep(list("topright"), length(variables)), 
                                      legend=rep(list(c("1", "2","3")), length(variables)), legend_text_width = strwidth("0.001"), na.rm=TRUE ){    
  
  # get_climate_data_objects returns a list of the climate_data objects specified in the arguments.
  # If no objects specified then all climate_data objects will be taken by default.
    
  if (!is.list(variables)){
    interest_var = list(variables)
  }
  data_list = add_to_data_info_required_variable_list(data_list,  variables) 
  # we should be able to specify the time period.
  data_list = add_to_data_info_time_period(data_list, time_period) 
  #Get the data objects
  climate_data_objs_list = get_climate_data_objects(data_list)
  
  #a count for the number of data sets 
  j = 1
  
  for(data_obj in climate_data_objs_list) {
    #get the name of the data set
    data_name = data_obj$get_meta(data_name_label)
        
    #adding year column if not present 
    if( !(data_obj$is_present( year_label ) ) ) {
      data_obj$add_year_month_day_cols() 
    }
    year_col = data_obj$getvname( year_label )
    
    curr_data_list = data_obj$get_data_for_analysis(data_list)
    
    for( curr_data in curr_data_list ) {
      #Plot multiple line at once
      matplot( curr_data[[year_col]], curr_data[interest_var[[j]]], col=col, lwd=lwd, type=type, lty=lty, xlab=xlabel,ylab=ylabel,main=c(data_name, main),
               ylim=c( range( curr_data[interest_var[[j]]], na.rm=na.rm) ))
      
      #Add points on top of the lines
      matpoints(curr_data[[ year_col ]], curr_data[ interest_var[[ j ]] ], type = "p", pch = pch,  col=col, lwd=lwd_points[[j]], lty=lty_points)
      
      #Add the legend
      legend( legend.location[[j]], legend=legend[[j]],  col=col, text.width = legend_text_width, bty=bty, lty = lty, text.col= col )
    }
    j=j+1
  }
}
)


