#there are still some bits of work to be done to finish cleaning this code.
#Appending functions there is currently a mismatch between adding col's to the data and adding variables I think these should probably be joined together in certain cases. 
#To get this to work really properly with respect to the get, set and append functions we may want to move to an R6 class where issues of private and public are properly adressed.


# Defining the reference class "climate_data".
# The fields are the properties every climate_data object will have.

climate_data <- setRefClass("climate_data", 
                            fields = list(data = "data.frame", meta_data = "list", 
                                          variables = "list", changes = "list", data_time_period="character"))



# INITIALIZE method
##############################################################################################
# Functions of reference classes are called methods.
# This is how you define a method for a specific reference class.
# Every reference class has an initialize method which tells R how to create new 
# climate_data objects.
# By the end of this method, all fields of climate_data should be defined.
# Notice that we don't have a climate_data object as an input.
# We can refer to any field of a climate_data object by name. e.g. data or variables

climate_data$methods(initialize = function(data = data.frame(), data_name = "", meta_data = list(), 
                                           variables = list(), imported_from = "", 
                                           messages = TRUE, convert=TRUE, create = TRUE, identify_variables = TRUE, 
                                           start_point=1, check_dates=TRUE, check_missing_dates = TRUE, 
                                           date_format = "%m/%d/%Y", data_time_period = "daily")
{
  
  # Set up the Climate data object
  
  .self$set_changes(list())
  .self$set_data(data, messages)
  .self$set_meta(add_defaults_meta(imported_from, meta_data))
  if (identify_variables) {
    .self$set_variables(add_defaults(imported_from, ident_var(data,variables)))
  }
  else{
    .self$set_variables(add_defaults(imported_from, variables))
  }
  
  # If no name for the data.frame has been given in the list we create a default one.
  # Decide how to choose default name index
  if (!.self$is_meta_data(data_name_label)) {    
    if ( ( is.null(data_name) || data_name == "" || missing(data_name))) {
      meta_data[[data_name_label]] <<- paste0("data_set_",sprintf("%03d", start_point))
      if (messages) {
        message(paste0("No name specified in data_tables list for data frame ", start_point, ". 
                         Data frame will have default name: ", "data_set_",sprintf("%03d", start_point)))
      }
    }
    else meta_data[[data_name_label]] <<- data_name      
  }
  
  .self$set_data_time_period(data_time_period)
  
  .self$date_format_check(convert=convert, messages=messages)
  
  if (check_dates){
    .self$date_col_check(date_format=date_format, convert=convert, create = create, messages=messages)
  }
  
  .self$check_multiple_data()
  
  if (check_missing_dates){
    .self$missing_dates_check(messages)
  }
  
  
}
)




# Getter methods
##############################################################################################
# We can create methods to extract fields from a climate_data object.
# These are called getter methods and are usually very simple functions.
# Notice that no input is needed.

climate_data$methods(get_data = function() {
  return(data)
}
)

climate_data$methods(get_data_for_analysis = function(data_info) {
  #TO DO error checking
  #This method for returning the subsets of the data is not optermised! It can be improved in a number of ways but should work very solidly and reliably in it's current form.
  
  merged_data=FALSE
  if (merge_data_label %in% names(data_info)){
    if (data_info[[merge_data_label]]){
      merged_data=TRUE
    }
  }
  return_data = data
  #  if (merged_data) return_data = data
  #  else{
  #    .self$check_split_data()
  #    return_data = split_data
  #  }
  if (station_list_label %in% names(data_info) & .self$is_present(station_label)) {
    return_data=return_data[return_data[[.self$getvname(station_label)]]==data_info[[station_list_label]],] #TO DO check this syntax is correct
  }
  if (date_list_label %in% names(data_info)) {
    for (tempname in names(data_info[[date_list_label]])){
      if (.self$is_present(tempname)){
        return_data=return_data[return_data[[.self$getvname(tempname)]]==data_info[[date_list_label]][[tempname]],] #TO DO check this syntax is correct and also add functionallity for start and end dates.
      }
    }
  }  
  if (!merged_data) return_data = .self$get_split_data(return_data)
  return (return_data)
  
}
)

climate_data$methods(get_variables = function() {
  return(variables)
}
)

#TO DO replace all direct calls with this!
climate_data$methods(getvname = function(label, create=FALSE) {
  if (label %in% names(variables)) {
    if (create) {
      if (!is_present(label)){
        if (label==year_label || label==month_label || label==day_label){
          add_year_month_day_cols()
        } else if (label==dos_label || label==season_label || label==doy_label) {
          add_doy_col()
        }# TODO Add other columns that could be created on the fly like time!
      }
    }
    return(variables[[label]])
  } else{
    return(label)
  }
}
)

climate_data$methods(get_changes = function() {
  return(changes)
}
)

climate_data$methods(get_data_time_period = function() {
  return(data_time_period)
}
)

climate_data$methods(get_meta = function(label="", overrider="") {
  
  if (label=="") return(meta_data)
  else if ( !(is.na(overrider)||(overrider=="")||missing(overrider) )) return(overrider)
  else if (.self$is_meta_data(label)) return(meta_data[[label]])
  else return (overrider)
}
)

climate_data$methods(get_station_data = function(currdata, label) {
  
  if (.self$is_present_or_meta(label)){
    if (.self$is_present(label)) {
      return (as.character(currdata[[getvname(label)]][[1]]))
    } else if (is_meta(label)){
      return (as.character(meta_data[[label]]))
    } else if (is_meta(station_list_label) & is_present(station_label) ) {
      return (as.character(meta_data[[station_list_label]][station_label==currdata[[station_label =getvname(station_label)]][[1]],label]))
    } 
  } else if ((label==station_label)) {
    return (get_meta(data_name_label))
  }
}
)

climate_data$methods(get_meta_new= function(label="", value_missing = FALSE, overrider="") {
  
  if (label=="") return(meta_data)
  else if ( !(missing(overrider)) && !(is.na(overrider)) && !value_missing ) return(overrider)
  else if (.self$is_meta_data(label)) return(meta_data[[label]])
  else return (overrider)
}
)

# Setter methods
##############################################################################################
# Similar to getter methods but used for setting a new value to one of the fields
# We usually do some validation before assigning.
#TO DO these setting methods are very dangerous if called directly, we need to either be much more carefull or make them private

climate_data$methods(set_data = function(new_data, messages=TRUE) {
  if( ! is.data.frame(new_data) ) {
    stop("Data set must be of type: data.frame")
  }
  else {
    if ( length(new_data) == 0 && messages) {
      message("data of object:is empty. data will be an empty data frame.")
    }
    data <<- new_data
    .self$append_to_changes(list(Set_property, "data"))
    #      is_data_split<<-FALSE
  }
}
)

climate_data$methods(set_meta = function(new_meta) {
  if( ! is.list(new_meta) ) {
    stop("Meta data must be of type: list")
  } else {
    meta_data <<- new_meta
    .self$append_to_changes(list(Set_property, "meta data"))
  }
}
)


climate_data$methods(set_variables = function(new_variables) {
  if( ! is.list(new_variables) ) {
    stop("Variables must be of type: list")
  }
  
  else {
    variables <<- new_variables
    .self$append_to_changes(list(Set_property, "variables"))
  }
}
)

climate_data$methods(set_changes = function(new_changes) {
  if( ! is.list(new_changes) ) {
    stop("Changes must be of type: list")
  }
  
  else {
    changes <<- new_changes
    .self$append_to_changes(list(Set_property, "changes"))  }
}
)

climate_data$methods(set_data_time_period = function(new_data_time_period) {
  if( ! is.character(new_data_time_period) ) {
    stop("Changes must be of type: character")
  }
  
  else {
    data_time_period <<- new_data_time_period
    .self$append_to_changes(list(Set_property, "data_time_period"))  }
}
)

############################################################################################
# We may want to add something to a field instead of replacing the whole field.
# For that we use append methods.


climate_data$methods(append_column_to_data = function(column_data, col_name = "", label) {
  
  # Column name must be character
  if( ! is.character(col_name) ) {
    stop("Column name must be of type: character")
  }
  
  # Column data length must match number of rows of data.
  else if ( !( length(column_data) == nrow(data) ) )
    stop(paste("Number of rows in new column does not match the number of rows in the data set.
                 There must be", nrow(data), "entries in the new column."))
  
  else {
    # If no name given, generate a default column name.
    if (col_name == "") {
      col_name = paste0("column_",sprintf("%02d", length(names(data))+1))
    }
    column_data <- unlist(column_data)
    data[[col_name]] <<- column_data
    .self$append_to_changes(list(Added_col, col_name))
    
    if(!missing(label)) {
      .self$append_to_variables(label,col_name)
    }
    
  }
}
)

climate_data$methods(replace_column_in_data = function(col_name = "", column_data) {
  
  # Column name must be character
  if( ! is.character(col_name) ) {
    stop("Column name must be of type: character")
  }
  
  else if (!(col_name %in% names(data))) {
    stop(paste0("Cannot replace column: ",col_name,". Column was not found in the data."))
  }
  
  # Column data length must match number of rows of data.
  else if ( !( length(column_data) == nrow(data) ) )
    stop(paste("Number of rows in new column does not match the number of rows in the data set.
                 There must be", nrow(data), "entries in the new column."))
  
  else {
    data[[col_name]] <<- column_data
    .self$append_to_changes(list(Replaced_col, col_name))
    #      is_data_split<<-FALSE
  }
}
)

climate_data$methods(rename_column_in_data = function(curr_col_name = "", new_col_name="") {
  
  # Column name must be character
  if( ! is.character(curr_col_name) ) {
    stop("Current column name must be of type: character")
  }
  
  else if (!(curr_col_name %in% names(data))) {
    stop(paste0("Cannot rename column: ",curr_col_name,". Column was not found in the data."))
  }
  
  else if (! is.character(new_col_name)) {
    stop("New column name must be of type: character")
  }
  
  else {
    if(sum(names(data) == curr_col_name) > 1) {
      warning(paste0("Multiple columns have name: '", curr_col_name,"'. All such columns will be 
                     renamed."))
    }
    names(data)[names(data) == curr_col_name] <<- new_col_name
    .self$append_to_changes(list(Renamed_col, curr_col_name, new_col_name))
    if(curr_col_name %in% variables) {
      .self$append_to_variables(names(which(variables==curr_col_name)), new_col_name)
    }
    
  }
}
)

climate_data$methods(remove_column_in_data = function(col_name = "") {
  
  # Column name must be character
  if( ! is.character(col_name) ) {
    stop("Column name must be of type: character")
  }
  
  else if (!(col_name %in% names(data))) {
    stop(paste0("Column :'", col_name, " was not found in the data."))
  }
  
  else {
    data[[ col_name ]] <<- NULL 
    .self$append_to_changes(list(Removed_col, col_name))
  }
}
)

climate_data$methods(replace_value_in_data = function(col_name = "", index, new_value = "") {
  
  # Column name must be character
  if( ! is.character(col_name) ) {
    stop("Column name must be of type: character")
  }
  
  else if (!(col_name %in% names(data))) {
    stop(paste("Cannot find column:",col_name,"in the data."))
  }
  
  # Column data length must match number of rows of data.
  else if ( missing(index) || !(is.numeric(index)) ) {
    stop(paste("Specify the index of the value to be replaced as an integer."))
  }
  
  else if (   index != as.integer(index) || index < 1 || index >  nrow(data) ) {
    stop( paste("index must be an integer between 1 and", nrow(data), ".") )
  }
  
  if ( class(data[[col_name]][[index]]) != class(new_value)) {
    warning("Class of new value does not match the class of the replaced value.")
  }
  
  old_value = data[[col_name]][[index]]
  data[[col_name]][[index]] <<- new_value
  .self$append_to_changes(list(Replaced_value, col_name, index, old_value, new_value))
  
}
)


climate_data$methods(append_to_meta_data = function(name, value) {
  
  if( missing(name) || missing(value) ) {
    stop("name and value arguements must be specified.")
  } 
  
  
  else if ( ! is.character(name) ) {
    stop("name must be of type: character")
  }
  
  # Remember double brackets must be used when dealing with variable names.
  else {
    meta_data[[name]] <<- value 
    .self$append_to_changes(list(Added_metadata, name))
  }
}
)

climate_data$methods(append_to_variables = function(label = "", value) {
  
  if( missing(label) || missing(value) ) {
    stop("label and value arguements must be specified.")
  } 
  
  
  else if ( ! is.character(label) ) {
    stop("label must be of type: character")
  }
  else {
    variables[[label]] <<- value 
    .self$append_to_changes(list(Added_col_label, label))
  }
}
)

climate_data$methods(append_to_changes = function(value) {
  
  if( missing(value) ) {
    stop(" value arguements must be specified.")
  } 
  else {
    changes[[length(changes)+1]] <<- value 
  }
}
)


# Other methods
############################################################################################

# is_present can check if a given variable name (or list of variable names) is in the data.frame or not.
# This will be used by other functions when doing calculations or to determine
# if extra columns should be added.
# TO DO check functionality for missing cols and if there are multiple elements in long format (currently will return true even if there are no instances possibly correct as like returning true when all values are missing?)

climate_data$methods(is_present = function(str, require_all=TRUE) {
  out = FALSE
  if (is.character(str) && length(str)==1){
    if(str %in% names(variables) ) {
      var_name = variables[[str]]
      if(var_name %in% names(data)) {
        out = TRUE
      }
    } else if(str %in% names(data)) {
      out = TRUE
    }
  }
  else if (is.character(str) || is.list(str)){
    for (temp in str){
      out=is_present(temp)
      if (require_all) if (!out) break
      if (!require_all) if (out) break
    }
  }
  return(out)
}
)

# is_present_or_meta can check if a given variable name (or list of variable names) is in the data.frame or the meta_data or neither.
# This will be used by other functions particularly related to station level data such as latitude, longditude etc. 
# TO DO check functionality for missing cols and if there are multiple elements in long format (currently will return true even if there are no instances possibly correct as like returning true when all values are missing?)

climate_data$methods(is_present_or_meta = function(str, require_all=TRUE) {
  out = FALSE
  if (is.character(str)){
    if(is_present(str)) {
      out = TRUE
    } else if(str %in% names(meta_data)){
      out = TRUE
    } else if(station_list_label %in% names(meta_data)){
      if(str %in% names(meta_data[[station_list_label]])) {
        out = TRUE
      }
    }
  }
  else if (is.list(str)){
    for (temp in str){
      out=is_present_or_meta(temp)
      if (require_all) if (!out) break
      if (!require_all) if (out) break
    }
  }
  return(out)
}
)

# is_meta_data can check if a given bit of meta data is available or not
# This will be used by other functions when doing calculations or to determine
# if extra columns should be added.

climate_data$methods(is_meta_data = function(str) {
  out = FALSE
  
  if(str %in% names(meta_data) ) {
    out = TRUE
  }
  return(out)
}
)

# check_multiple_data checks if there are factor columns with either more than one station or more than one element 
# This will be used to know if the data needs to be subsetted or not.

climate_data$methods(check_multiple_data = function() {
  
  if(!(.self$is_meta_data(multiple_station_label))) {
    if (.self$is_present(station_label)){
      if (nlevels(as.factor(data[[.self$getvname(station_label)]]))>1) meta_data[[multiple_station_label]]<<-TRUE
      else meta_data[[multiple_station_label]]<<-FALSE
    }
    else meta_data[[multiple_station_label]]<<-FALSE
  }
  if(!(.self$is_meta_data(multiple_element_label))) {
    if (.self$is_present(element_factor_label)){
      if (nlevels(as.factor(data[[.self$getvname(element_factor_label)]]))>1) meta_data[[multiple_element_label]]<<-TRUE
      else meta_data[[multiple_element_label]]<<-FALSE
    }
    else meta_data[[multiple_element_label]]<<-FALSE
  }
}
)

# check_split_data assigns the data to the split_data taking into account station and element TO DO this probably needs to be optermised for large data
# Replaced by get_split_data below since the split data is no longer stored
#
#climate_data$methods(check_split_data = function() {
#  
#  if(!(is_data_split)) {
#    if (meta_data[[multiple_station_label]]==TRUE & meta_data[[multiple_element_label]]==TRUE){
#      split_data <<- split(data, list(as.factor(data[[.self$getvname(station_label)]]),as.factor(data[[.self$getvname(element_factor_label)]])))
#    }
#    else if (meta_data[[multiple_station_label]]==TRUE){
#      split_data <<- split(data, as.factor(data[[.self$getvname(station_label)]]))
#    }
#    else if (meta_data[[multiple_element_label]]==TRUE){
#      split_data <<- split(data, as.factor(data[[.self$getvname(element_factor_label)]]))
#    }
#    else split_data <<- list(data)
#    is_data_split<<-TRUE
#  }
#}
#)

climate_data$methods(get_split_data = function(return_data) {
  
  if (meta_data[[multiple_station_label]]==TRUE & meta_data[[multiple_element_label]]==TRUE){
    split_data <- split(return_data, list(as.factor(return_data[[.self$getvname(station_label)]]),as.factor(return_data[[.self$getvname(element_factor_label)]])))
  }
  else if (meta_data[[multiple_station_label]]==TRUE){
    split_data <- split(return_data, as.factor(return_data[[.self$getvname(station_label)]]))
  }
  else if (meta_data[[multiple_element_label]]==TRUE){
    split_data <- split(return_data, as.factor(data[[.self$getvname(element_factor_label)]]))
  }
  else split_data <- list(return_data)
  return(split_data)
}
)

#==========================================================================
# date_col_check
# Method to check if date column is present and in correct format
# If the column is not there then it is created
# Danny's changes:
# Changed name
# Added convert and create arguements
# Added date_format as arguement
# Date column name is not changed if date column is already there
# Created replace_column_in_data method for climate_data to use to change class of date column
# TODO implement full range of options particularly for subdaily data

climate_data$methods(date_col_check = function(date_format = "%d/%m/%Y", convert = TRUE, create = TRUE, messages=TRUE)
{ 
  # Check if there is a date column already
  # Check if the date is in the Date class
  # If convert == TRUE
  # Convert class to date class
  
  if(data_time_period==subdaily_label) {
    
    if (.self$is_present(date_time_label)) {
      date_time_col = getvname(date_time_label)
      if (!is.POSIXct(data[[date_time_col]])) {
        if (messages) message("date-time column is not stored as POSIXct class.")
        if (convert) {
          if (messages) message("Attempting to convert date column to POSIXct class.")
          new_col = as.POSIXct(data[[date_time_col]], format = date_format)
          .self$replace_column_in_data(date_time_col,new_col)
        }
      }
    }
    else if(create && is_present(date_label) && is_present(time_label)) {
      time_col = getvname(time_label)
      if(grepl(":",data[[time_col]][[1]])) {
        if(nchar(data[[time_col]][[1]]==5)) time_format = "%H:%M"
        else if(nchar(data[[time_col]][[1]]==7)) time_format = "%H:%M:%S"
        else stop("Cannot recognise the format of time column.")
      }
      else if(nchar(data[[time_col]][[1]]==4)) time_format = "%H%M"
      else if(nchar(data[[time_col]][[1]]==6)) time_format = "%H%M%S"
      else stop("Cannot recognise the format of time column.")
      date_col = getvname(date_label)
      new_col = as.POSIXct(paste(data[[date_col]],data[[time_col]]),
                           format = paste("%Y-%m-%d",time_format))
      .self$append_column_to_data(new_col, getvname(date_time_label))        
    }
    else if (create && is_present(date_asstring_label)) 
    {
      date_string_col = getvname(date_asstring_label)
      new_col = as.POSIXct(data[[date_string_col]], format = date_format)
      .self$append_column_to_data(new_col,getvname(date_time_label))
    }
    else if (create && is_present(date_label)) 
    {
      date_col = getvname(date_label)
      new_col = as.POSIXct(data[[date_col]], format = date_format)
      .self$append_column_to_data(new_col,getvname(date_time_label))
    }
  }
  if (.self$is_present(date_label)) {
    date_col = getvname(date_label)
    if (!is.Date(data[[date_col]])) {
      if (messages) message("date column is not stored as Date class.")
      if (convert) {
        if (messages) message("Attempting to convert date column to Date class.")
        new_col = as.Date(as.character(data[[date_col]]), format = date_format)
        #if the two digit year format is used then by default R makes dates into the future whereas it makes more sense in our context to assume dates are in the past. 
        if (grepl("%y",date_format)) {
          .self$replace_column_in_data(date_col,as.Date(ifelse(new_col > Sys.Date(),format(new_col, "19%y-%m-%d"), format(new_col))))
        } else {
          .self$replace_column_in_data(date_col,new_col)
        }
      }
    }
  }
  
  
  # Else if date string column is there and create == TRUE create date column
  else if (create && is_present(date_asstring_label)) 
  {
    date_string_col = getvname(date_asstring_label)
    new_col = as.Date(data[[date_string_col]], format = date_format)
    .self$append_column_to_data(new_col,getvname(date_label))
  }

  # Else if date time column is there and create == TRUE create date column
  else if (create && is_present(date_time_label)) 
  {
    date_string_col = getvname(date_time_label)
    new_col = as.Date(data[[date_string_col]], format = date_format)
    .self$append_column_to_data(new_col,getvname(date_label))
  }
  
  # If the year, month, day column are there and create == TRUE create date column
  else if (create && is_present(year_label) && is_present(month_label) && is_present(day_label))
  {
    day_col = data[[getvname(day_label)]]
    month_col = data[[getvname(month_label)]]
    year_col = data[[getvname(year_label)]]
    
    if(all(month.abb %in% month_col)) {
      month_col = match(month_col,month.abb)
    }
    
    if(all(month.name %in% month_col)) {
      month_col = match(month_col,month.abb)
    }
    
    new_col = as.Date(paste(year_col, month_col, day_col, sep="-"))
    .self$append_column_to_data(new_col, getvname(date_label))
  }
  
  else if (create && is_present(year_label) && is_present(doy_label)) {
    year_col = data[[getvname(year_label)]]
    doy_col = data[[getvname(doy_label)]]
    new_col = do.call(c,mapply(doy_as_date,as.list(doy_col),as.list(year_col), SIMPLIFY=FALSE))
    .self$append_column_to_data(new_col,getvname(date_label))
  }
  
  # Else check time period specific cases
  else if (data_time_period==subdaily_label || data_time_period==daily_label) {
    warning("Cannot create or edit a date column. There is insufficient information in the
                  data frame to have a date column.")
  }
  
  else if (data_time_period==subyearly_label) {
    
    if (create == TRUE && is_present(year_month_label)) {
      year_month_col = data[[getvname(year_month_label)]]
      new_col = as.Date(paste(year_month_col,"1"), format = paste(date_format,"%d"))
      .self$append_column_to_data(new_col,variables[[date_label]])
    }
    
    else if (create && is_present(year_label) && is_present(month_label)) {
      year_col = data[[getvname(year_label)]]
      month_col = data[[getvname(month_label)]]
      if(all(month.abb %in% month_col)) {
        month_col = match(month_col,month.abb)
      }
      if(all(month.name %in% month_col)) {
        month_col = match(month_col,month.abb)
      }
      new_col = as.Date(paste(year_col,month_col,"1"), format = "%Y %m %d")
      .self$append_column_to_data(new_col,variables[[date_label]])
    }
    
    else {warning("Cannot create or edit a date column. There is insufficient information in the
                  data frame to have a date column.")}
  }
  
  else if (data_time_period==yearly_label) {
    if (create && is_present(year_label)) {
      year_col = variables[[year_label]]
      new_col = as.Date(paste(data[[year_col]],1,1), format = "%Y %m %d")
      .self$append_column_to_data(new_col,variables[[date_label]])
    }
    
    else {warning("Cannot create or edit a date column. There is insufficient information in the
                  data frame to have a date column.")}
  }
}
)

climate_data$methods(missing_dates_check = function(messages = TRUE)
{    
  # TO DO fill in missing dates for other time periods. Also check for DOY DOS ...
  
  if(data_time_period == daily_label) {
    date_col = getvname(date_label)
    if(anyNA(data[[date_col]])){
      if (messages){
        warning("The following data has been removed from your dataset because the date column was missing")
        warning(subset(data,is.na(data[[date_col]])))
      }
      .self$set_data(subset(data,!is.na(data[[date_col]])), messages)
    }
  }
  
  if(!get_meta(complete_dates_label)) {
    if(data_time_period == daily_label) {
      by = "day"
      
      start_end_dates = .self$get_data_start_end_dates()
      
      #     append_to_meta_data(data_start_date_label,start_date)
      #     append_to_meta_data(data_end_date_label,end_date)
      full_dates = seq(start_end_dates[[1]], start_end_dates[[2]], by = by)
      #TODO in missing data check need to get it working for multiple stations!
      if(length(full_dates) > nrow(data)) {
        dates_table = data.frame(full_dates)
        names(dates_table) <- date_col
        if(is_present(year_label)) {
          year_col = getvname(year_label)
          dates_table[[year_col]] <- year(dates_table[[date_col]]) 
        }
        if(is_present(month_label)) {
          month_col = getvname(month_label)
          dates_table[[month_col]] <- month(dates_table[[date_col]]) 
        }
        if(is_present(day_label)) {
          day_col = getvname(day_label)
          dates_table[[day_col]] <- day(dates_table[[date_col]]) 
        }
        merged_data <- join(dates_table, get_data(), match="first")
        set_data(merged_data)
      }
      append_to_meta_data(complete_dates_label,TRUE)
    }
  }
} 
)

#add_year_month_day_cols simply converts a date column to Year month and day if they don't exist.
#TO DO Should be adapted for other types of data_time_period currently just for daily

climate_data$methods(add_year_month_day_cols = function(date_format="%d/%m/%Y", YearLabel="Year", MonthLabel="Month", DayLabel="Day")
{
  if (.self$is_present( date_label)){
    date_col = variables[[date_label]]
    if (!.self$is_present(year_label)){
      .self$append_column_to_data (year(data[[date_col]]), YearLabel) 
      .self$append_to_variables(year_label, YearLabel)
    }
    if (!data_time_period==yearly_label){      
      if (!.self$is_present(month_label)){
        .self$append_column_to_data (month(data[[date_col]]), MonthLabel) 
        .self$append_to_variables(month_label, MonthLabel)
      }
      if (!data_time_period==subyearly_label) {
        if (!.self$is_present(day_label)){
          .self$append_column_to_data (day(data[[date_col]]), DayLabel) 
          .self$append_to_variables(day_label, DayLabel)
        }
      }
    }
  }
  else warning("No Date column check that your data has date information and create a date colum using date_col_check.")
  
}
)

climate_data$methods(add_doy_col = function(YearLabel="Year", DOYLabel="DOY", SeasonLabel="Season", DOSLabel="DOS")
  
{
  if (.self$is_present(date_label)){
    
    date_col = variables[[date_label]]
    if (!.self$is_present(year_label)){
      .self$append_column_to_data (year(data[[date_col]]), YearLabel) 
      .self$append_to_variables(year_label, YearLabel)
    }
    if (!.self$is_present(doy_label)){
      TEMPDOY = yday(data[[date_col]])      
      temply=leap_year(data[[date_col]])
      TEMPDOY[((TEMPDOY > 59) & (!(temply)))] <- 1 + TEMPDOY[((TEMPDOY > 59)&(!(temply)))]
      .self$append_column_to_data (TEMPDOY, DOYLabel) 
      .self$append_to_variables(doy_label, DOYLabel)
    }
    if (is_meta_data(season_start_day_label)){
      #--------------------------------------------------------------#
      # find the specified start date of the year in 366 form
      #--------------------------------------------------------------#
      if (((dos_label==doy_label)||(year_label==season_label))||!(.self$is_present(dos_label)||.self$is_present(season_label))){
        if (1<meta_data[[season_start_day_label]] & meta_data[[season_start_day_label]]<367){
          TEMPDOY <- data[[variables[[doy_label]]]]
          TEMPDOS <- TEMPDOY - meta_data[[season_start_day_label]] + 1
          #TO DO allow flexibility for how season is written.
          TEMPSEASON=data[[variables[[year_label]]]]
          TEMPSEASON[(TEMPDOS < 1)]<-paste(as.numeric(TEMPSEASON[(TEMPDOS < 1)])-1, TEMPSEASON[(TEMPDOS < 1)],sep = "-")
          TEMPSEASON[(TEMPDOS > 0)]<-paste(TEMPSEASON[(TEMPDOS > 0)], as.numeric(TEMPSEASON[(TEMPDOS > 0)])+1,sep = "-")
          TEMPDOS[(TEMPDOS < 1)] <- TEMPDOS[(TEMPDOS < 1)] + 366
          .self$append_column_to_data (TEMPDOS, DOSLabel) 
          .self$append_to_variables(dos_label, DOSLabel)
          .self$append_column_to_data (as.factor(TEMPSEASON), SeasonLabel) 
          .self$append_to_variables(season_label, SeasonLabel)
        }
        else{
          .self$append_to_variables(dos_label, DOYLabel)
          .self$append_to_variables(season_label, YearLabel)
        }
      }
      else{
        .self$append_to_variables(dos_label, DOYLabel)
        .self$append_to_variables(season_label, YearLabel)
      }      
    }
  }
  else warning("No Date column check that your data has date information and create a date colum using date_col_check.")  
}
)
#TO DO Conversions to other cases

climate_data$methods(summarize_data = function(new_time_period, summarize_name = paste(.self$meta_data[[data_name_label]],new_time_period), 
                                               threshold = 0.85, na.rm = FALSE, start_point = 1, 
                                               num_rain_days_col = "Number of Rain Days", total_col = "Total",
                                               mean_col = "Mean", period_col_name = "Period", 
                                               mean_rain_name = "Average rain per rain day", factor_col)
  
  # TO DO remove date formats, remove threshold, 
{
  if(missing(new_time_period)) {
    stop("Specify the time period you want the summarized data to be in.")
  }
  
  if(!compare_time_periods(new_time_period,data_time_period)) {
    stop("Cannot summarize data to a shorter time period.")
  }
  
  date_col_name = getvname(date_label)
  date_col = data[[date_col_name]]
  
  curr_data_name = get_meta(data_name_label)
  
  if(new_time_period == daily_label) {
    
    # TO DO work out how to do missing_dates_check for subdaily data
    .self$missing_dates_check()
    
    unique_dates = unique(data[[date_col_name]])
    
    summarized_data = data.frame(unique_dates)
    names(summarized_data) <- date_col_name
    summary_obj = climate_data$new(data = summarized_data, data_name = summarize_name, 
                                   start_point = start_point, data_time_period = new_time_period,
                                   # This can be removed once missing_dates_check works for subdaily data
                                   check_missing_dates = FALSE)
    View(summary_obj$data)
    split_col = date_col_name
  }
  
  else if(new_time_period == subyearly_label) {
    #TO DO allow to summarize to subyearly by using the factor_col argument
    #      need to think how date column will be created for subyearly summary
  }
  
  else if(new_time_period == yearly_label) {
    
    start_date = .self$get_data_start_end_dates()[[1]]
    end_date = .self$get_data_start_end_dates()[[2]]+1
    year(end_date) = year(end_date)-1
    season_dates = seq(start_date,end_date,"year")
    
    if(!is_present(season_label)) add_doy_col()
    season_col = getvname(season_label)
    unique_seasons = unique(data[[season_col]])
    
    summarized_data = data.frame(unique_seasons)
    names(summarized_data) <- season_col
    summarized_data[[date_col_name]] <- season_dates
    
    summary_obj = climate_data$new(data = summarized_data, data_name = summarize_name, 
                                   start_point = start_point, data_time_period = new_time_period)
    
    summary_obj$append_to_variables(season_label,season_col)
    
    split_col = season_col
    
  }
  
  summary_obj$append_to_variables(date_label,date_col_name)
  
  summary_obj$append_to_meta_data(summary_statistics_label,list())
  
  summ_date_col_name = summary_obj$getvname(date_label)
  summ_split_col = summary_obj$data[[split_col]]
  
  if(new_time_period != yearly_label) {
    if( !summary_obj$is_present(month_label) && .self$is_present(month_label) ) {
      summary_obj$append_column_to_data(month(summ_date_col_name),getvname(month_label))
      summary_obj$append_to_variables(month_label,getvname(month_label))
    }
  }
  
  if( new_time_period == daily_label ) {
    if( !summary_obj$is_present(season_label) && .self$is_present(day_label) ) {
      summary_obj$append_column_to_data(day(summ_date_col_name),getvname(day_label))
      summary_obj$append_to_variables(day_label,getvname(day_label))
    }
  }
  
  if( !summary_obj$is_present(season_label) && .self$is_present(season_label) ) {
    #TO DO how to work out seasons from the dates
    #      do we need a season function similar to year()?
  }
  
  if( !summary_obj$is_present(year_label) && .self$is_present(year_label) ) {
    summary_obj$append_column_to_data(year(summ_date_col_name),getvname(year_label))
    summary_obj$append_to_variables(year_label,getvname(year_label))
  }
  
  
  summarized_row_num = nrow(summary_obj$data)
  
  for(var in c(rain_label, temp_min_label, temp_max_label, evaporation_label,temp_air_label)) {
    # For the variables that are present we create summaries    
    if(is_present(var)) {
      curr_col_name = .self$getvname(var)
      
      # For rain we will add number total rainfall
      # And for yearly summaries from subdaily or daily also number of rainy days and average rain on rainy day
      if(var == rain_label) {
        threshold = get_meta_new(threshold_label,missing(threshold),threshold)
        
        total_rain_data = as.vector(by(data[[curr_col_name]],data[[split_col]], sum, na.rm = na.rm))
        total_rain_name = paste(total_col,curr_col_name)
        summary_obj$append_column_to_data(total_rain_data, total_rain_name)
        rain_total_label = summary_obj$get_summary_label(var, total_label, list(na.rm=na.rm))
        summary_obj$append_to_variables(rain_total_label, total_rain_name)
        
        # TO DO how do we do this when summarizing from subdaily as well?
        if( (data_time_period == daily_label) && new_time_period == yearly_label) {
          
          # Can't use by function here as there may be no values > threshold causing by to skip
          # a time period, causing an error when we try to append the column.
          mean_rain_data = c()
          for(period in summ_split_col) {
            curr_mean = mean(data[[curr_col_name]][data[[split_col]]==period & data[[curr_col_name]] > threshold], na.rm=na.rm)
            mean_rain_data = c(mean_rain_data, curr_mean)
          }
          
          summary_obj$append_column_to_data(mean_rain_data, mean_rain_name)
          mean_rain_label = summary_obj$get_summary_label(var, mean_label, list(na.rm=na.rm, threshold = threshold))
          summary_obj$append_to_variables(mean_rain_label, mean_rain_name)
          
          
          num_rain_days_data = as.vector(by(data[[curr_col_name]] > threshold, 
                                            data[[split_col]], sum, na.rm=na.rm))
          
          summary_obj$append_column_to_data(num_rain_days_data, num_rain_days_col)
          rain_days_label = summary_obj$get_summary_label(var, number_of_label, list(na.rm=na.rm, threshold=threshold))
          summary_obj$append_to_variables(rain_days_label,num_rain_days_col)
        }
      }
      
      else {
        
        # For all other variables we add the mean only.  
        mean_var_data = as.vector(by(data[[curr_col_name]],data[[split_col]], mean, na.rm = na.rm))
        mean_var_name = paste(mean_col,curr_col_name)
        summary_obj$append_column_to_data(mean_var_data, mean_var_name)
        mean_var_label = summary_obj$get_summary_label(var, mean_label, list(na.rm=na.rm))
        summary_obj$append_to_variables(mean_var_label, mean_var_name)
      }  
      
      
    }
  }
  
  summary_obj$append_to_meta_data(summarized_from_label, curr_data_name)
  
  summary_obj
  
}
)

climate_data$methods(add_water_balance_col = function(col_name = "Water Balance", capacity_max = 100, evaporation = 5)
{
  
  # Complete dates needed for calculations
  missing_dates_check()
  
  # Always use the methods to get value from objects. Never access directly.
  rain_col = getvname(rain_label)
  date_col = getvname(date_label)
  
  # Do all data_object level checks before calling get_data_for_analysis
  evap_present = is_present(evaporation_label)
  if(evap_present) evaporation_col = getvname(evaporation_label)
  
  # New get_meta method (waiting for David to check)
  capacity_max = get_meta_new(capacity_label,missing(capacity_max),capacity_max)
  
  # Use an empty data_list here because we want to calculate water balance
  # for the whole data set.
  # Displaying water balance can use a non empty data_list here if we want to view a subset of the data
  curr_data_list = get_data_for_analysis(data_info = list())
  
  for( curr_data in curr_data_list ) {
    # This needs to be changed to consider case when data will come as split
    # Index comparisions etc.
    
    num_rows <- nrow(curr_data)
    
    # List of the indices of all NAs in the rain column
    #indicNAs <- which (curr_data[[ rain_col ]] %in% NA)
    
    # Create a column for water balance filled with NAs
    # We will append to data_object only when it is complete
    water_balance_col = rep(NA,num_rows)
    
    # Initialization
    if( is.na(curr_data[[rain_col]][[1]]) ) {
      water_balance_col[[1]] <- NA
    }
    else {water_balance_col[[1]] <- 0}
    
    #       if(length(indicNAs) != 0) {
    #         ind_nonrecord = indicNAs[ !(day(curr_data[[date_col]][indicNAs]) == 29 & month(curr_data[[date_col]][indicNAs]) == 2) ]
    #       }
    #       else {ind_nonrecord <- indicNAs}
    
    #      ind_nonrecord <- indicNAs
    
    # assign the NAs due to non recording values to be zero.
    #       for(  j in ind_nonrecord  ) {
    #         curr_data[[ rain_col ]][ j ] = 0
    #       }
    
    
    reset <- which(day(curr_data[[ date_col ]]) == 1 &  month(curr_data[[ date_col ]]) == 1)
    
    # Two different formulas for computing water balance depending on what kind of evaporation
    # you have.
    for (  iday in 2 : num_rows  ) {
      if(evap_present) {evaporation <- evap_col[[iday]]}
      
      if( iday %in% reset && is.na(water_balance_col[iday - 1]) ) {
        water_balance_col[[iday]] <- 0
      }
      else {
        water_balance_col[[iday]] <- water_balance_col[[iday - 1]] + curr_data[[rain_col]][iday] - evaporation
      }
      
      if( !is.na(water_balance_col[iday]) ) {
        if ( water_balance_col[iday] < 0 ) {
          water_balance_col[iday] <- 0
        }
        else if( water_balance_col[iday] > capacity_max ) {
          water_balance_col[iday] <- capacity_max
        }
      }
    }
  }
  
  # Last step is to append the water balance column to the data
  # and add to variables so that water balance can be recognised.
  append_column_to_data(water_balance_col,col_name)
  append_to_variables(waterbalance_label, col_name)
}
)


climate_data$methods(get_summary_label = function(element="", statistic="", definition=list()) {
  
  if( !is_meta_data(summary_statistics_label)) {
    append_to_meta_data(summary_statistics_label,list())
  }
  
  if( !(element %in% names(meta_data[[summary_statistics_label]])) ) {
    meta_data[[summary_statistics_label]][[element]] <<- list()
  }
  
  if( !(statistic %in% names(meta_data[[summary_statistics_label]][[element]])) ) {
    meta_data[[summary_statistics_label]][[element]][[statistic]] <<- list()    
  }
  
  label = paste(element,statistic,length(meta_data[[summary_statistics_label]][[element]][[statistic]])+1)
  meta_data[[summary_statistics_label]][[element]][[statistic]][[label]] <<- definition
  
  return(label)
}
)

climate_data$methods(is_definition = function(element="", statistic="", definition=list()) {
  
  found_match = FALSE
  
  if( is_meta_data(summary_statistics_label) 
      && element %in% names(meta_data[[summary_statistics_label]])
      && statistic %in% names(meta_data[[summary_statistics_label]][[element]]) ) {
    for(def in meta_data[[summary_statistics_label]][[element]][[statistic]]) {
      if(length(def) != length(definition)) break
      match = TRUE
      for(item in names(def)) {
        if( !(item %in% names(definition) && def[[item]] == definition[[item]]) ) {
          match = FALSE
          break
        }
      }
      if(match) {
        found_match = TRUE
        break
      }
    }
  }
  
  return(found_match)
  
}
)

climate_data$methods(view_definition = function(col_name) {
  
  if (col_name %in% names(data)) {
    
    label = names(which(variables==col_name))
    if(is_meta_data(summary_statistics_label)) {
      for(element in meta_data[[summary_statistics_label]]) {
        for(statistic in element) {
          if(label %in% names(statistic)) {
            ind = which(names(statistic)==label)
            return(statistic[[ind]])
          }
        }
      }
    }
  }
  else return(NA)
}
)

climate_data$methods(get_data_start_end_dates = function() {
  # TO DO better method for getting subyeary and yearly dates
  date_col = getvname(date_label)
  temp_start_date = doy_as_date(get_meta(season_start_day_label),year(min(data[[date_col]])))
  if( temp_start_date > min(data[[date_col]]) ) {
    start_date = temp_start_date
    year(start_date) <- year(start_date)-1
  }
  else {
    start_date = temp_start_date      
  }
  
  final_year = year(max(data[[date_col]]))
  final_month = month(start_date-1)
  final_day = day(start_date-1)
  temp_end_date = as.Date(paste(final_year,final_month,final_day,sep="-"))
  if( temp_end_date >= max(data[[date_col]]) ) {
    end_date = temp_end_date
  }
  else {
    end_date = as.Date(paste(final_year+1,final_month,final_day,sep="-"))
  }
  
  return(c(start_date,end_date))
}
)

climate_data$methods(time_period_check = function(messages=TRUE) {
  
  date_col = data[[getvname(date_label)]]
  diff_values = difftime(tail(date_col,-1),head(date_col,-1), units="days")
  min_diff = min(diff_values)
  median_diff = median(diff_values)
  mode_diff = mode_stat(diff_values)
  
  if(min_diff < 1) {
    data_time_period <<- subdaily_label
  }
  else if (min_diff == 1) {
    data_time_period <<- daily_label
  }
  else if (min_diff > 1 && min_diff < 365) {
    data_time_period <<- subyearly_label
  }
  else if (min_diff == 365) {
    data_time_period <<- yearly_label
  }
  else {
    stop("Cannot determine the data time period.")
  }
  
  if(messages) message(paste("Detected time period:", data_time_period))
  if(messages && (min_diff != median_diff) ) {
    warning(paste("The data time period does not match with the median time difference:", median_diff))
  }
  if(messages && min_diff != mode_diff) {
    warning(paste("The data time period does not match with the mode time difference:", mode_diff))
  }
  
}
)

climate_data$methods(date_format_check = function(convert = TRUE, messages=TRUE) {
  
  if(is_present(month_label)) {
    month_col = data[[getvname(month_label)]]
    if(convert && all(month.abb %in% month_col)) {
      if(messages) message("Converting month column to ordered factor.")
      replace_column_in_data(getvname(month_label),factor(data[[getvname(month_label)]], month.abb, ordered=TRUE))
    }
    
    else if(convert && all(month.name %in% month_col)) {
      if(messages) message("Converting month column to ordered factor.")
      replace_column_in_data(getvname(month_label),factor(data[[getvname(month_label)]], month.name, ordered=TRUE))
    }
  }
  
}
)


climate_data$methods(add_spell_length_col = function(col_name = "spell_length", threshold)
{
  
  # Complete dates needed for calculations
  missing_dates_check()
  
  rain_col = getvname(rain_label)  
  
  curr_data_list = get_data_for_analysis(data_info = list())
  
  for( curr_data in curr_data_list ) {    
    
    num_rows <- nrow(curr_data)       
    
    spell_length_col = curr_data[[rain_col]]    
    
    spell_length_col[spell_length_col <= threshold] <- 0 
    
    if (spell_length_col[1]<threshold|is.na(spell_length_col[[1]])){
      spell_length_col[1]=NA      
    }
    for (i in 2:num_rows){
      if ((spell_length_col[i]<threshold|is.na(spell_length_col[i])) & is.na(spell_length_col[i-1])){
        spell_length_col[i]=NA 
      }        
    }
    
    spell_length_col=spell_length_count (spell_length_col)   
    
  }    
    append_column_to_data(spell_length_col,col_name)
    append_to_variables(spell_length_label, col_name)
}
)


climate_data$methods(add_running_rain_totals_col = function(col_name = "Running Rain Total",threshold = 0.85, total_days = 1)
{
  
  # Complete dates needed for calculations
  missing_dates_check()
  
  rain_col = getvname(rain_label)  
  
  curr_data_list = get_data_for_analysis(data_info = list())
  
  for( curr_data in curr_data_list ) {    
    
    num_rows <- nrow(curr_data)      
    
    
    running_totals_col = curr_data[[rain_col]]
    
    
    running_totals_col[running_totals_col <= threshold] <- 0
    
    running_totals_col = c(rep(NA, (total_days -1)),running_sum(data = running_totals_col, total_days = total_days))
        
  }    
  append_column_to_data(running_totals_col,col_name)
  append_to_variables(running_rain_totals_label, col_name)
}
)
