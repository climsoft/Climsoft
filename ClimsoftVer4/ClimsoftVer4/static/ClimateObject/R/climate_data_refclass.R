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
        return_data=return_data[return_data[[.self$getvname(tempname)]] %in% data_info[[date_list_label]][[tempname]],] #TO DO add functionallity for start and end dates.
      }
    }
  }  
  
  if(threshold_list_label %in% names(data_info)) {
    if(var_label %in% names(data_info[[threshold_list_label]]) 
       && .self$is_present(data_info[[threshold_list_label]][[var_label]])) {
      var = .self$getvname(data_info[[threshold_list_label]][[var_label]])
      
      if(!(lower_strict_label %in% names(data_info[[threshold_list_label]]))) lower_strict = FALSE
      else lower_strict = data_info[[threshold_list_label]][[lower_strict_label]]

      if(!(upper_strict_label %in% names(data_info[[threshold_list_label]]))) upper_strict = FALSE
      else upper_strict = data_info[[threshold_list_label]][[upper_strict_label]]

      if(lower_threshold_label %in% names(data_info[[threshold_list_label]]) && data_info[[threshold_list_label]][[lower_threshold_label]] != "") lower_threshold = data_info[[threshold_list_label]][[lower_threshold_label]]
      else lower_threshold = ""
      if(upper_threshold_label %in% names(data_info[[threshold_list_label]]) && data_info[[threshold_list_label]][[upper_threshold_label]] != "") upper_threshold = data_info[[threshold_list_label]][[upper_threshold_label]]
      else upper_threshold = ""
      
      if( lower_threshold != "" && upper_threshold != "" ) {
        if(lower_strict && upper_strict) return_data = return_data[return_data[[var]] > lower_threshold & return_data[[var]] < upper_threshold,]
        else if(lower_strict) return_data = return_data[return_data[[var]] > lower_threshold & return_data[[var]] <= upper_threshold,]
        else if(upper_strict) return_data = return_data[return_data[[var]] >= lower_threshold & return_data[[var]] < upper_threshold,]
        else return_data = return_data[return_data[[var]] >= lower_threshold & return_data[[var]] <= upper_threshold,]
      }
      
      else if(lower_threshold != "") {
        if(lower_threshold == use_default_label) lower_threshold = .self$get_meta(threshold_label, overrider = default_threshold)
        if(lower_strict) return_data = return_data[return_data[[var]] > lower_threshold,]
        else return_data = return_data[return_data[[var]] >= lower_threshold,]
      }
      
      else if(upper_threshold != "") {
        if(upper_strict) return_data = return_data[return_data[[var]] < upper_threshold,]
        else return_data = return_data[return_data[[var]] <= upper_threshold,]
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
  out = c()
  i = 1
  for(single_label in label) {
    if (single_label %in% names(variables)) {
      if (create) {
        if (!is_present(single_label)){
          if (single_label==year_label || single_label==month_label || single_label==day_label){
            add_year_month_day_cols()
          } else if (single_label==dos_label || single_label==season_label || single_label==doy_label) {
            .self$add_doy_col()
          }# TODO Add other columns that could be created on the fly like time!
        }
      }
      out[i] = variables[[single_label]]
    } 
    else out[i] = label
    i = i + 1
  }
  out
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

climate_data$methods(get_meta= function(label="", value_missing = FALSE, overrider="") {
  
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


climate_data$methods(append_column_to_data = function(column_data, col_name = "", label = "", replace = FALSE) {
  
  # Column name must be character
  if( ! is.character(col_name) ) stop("Column name must be of type: character")
  
  # Column data length must match number of rows of data.
  if ( !( length(column_data) == nrow(data) ) ) {
    stop(paste("Number of rows in new column does not match the number of rows in the data set.
                 There must be", nrow(data), "entries in the new column."))
  }
  

  column_data <- unlist(column_data)
  # If no name given, generate a default column name.
  if (col_name == "") {
    col_name = paste0("column_",sprintf("%02d", length(names(data))+1))
  }
  
  if(!missing(label)) {
    if(.self$is_present(label)) {
      message(paste("A variable for", label, "already exists."))
      if(replace) {
        message("The variable will be replaced in the data")
        data[[col_name]] <<- column_data
        .self$append_to_variables(label,col_name)
        .self$append_to_changes(list(Replaced_col, col_name))
      }
      else message("The variable will not be replaced. Specify replace = TRUE to replace this variable.")
    }
    
    else {
      if(col_name %in% names(data)) {
        message(paste("A column named", col_name, "already exists."))
        if(replace) {
          message("The variable will be replaced in the data")
          data[[col_name]] <<- column_data
          .self$append_to_variables(label,col_name)
          .self$append_to_changes(list(Replaced_col, col_name))
        }
        else message("The column will not be replaced. Specify replace = TRUE to replace this column.")
      }
      else {
        data[[col_name]] <<- column_data
        .self$append_to_variables(label,col_name)
        .self$append_to_changes(list(Added_col, col_name))
      }
    }
  }

  else if(col_name %in% names(data)) {
    message(paste("A column named", col_name, "already exists."))
    if(replace) {
      message("The variable will be replaced in the data")
      data[[col_name]] <<- column_data
      .self$append_to_changes(list(Replaced_col, col_name))
    }
    else message("The column will not be replaced. Specify replace = TRUE to replace this column.")
  }
  
  else {
    data[[col_name]] <<- column_data
    .self$append_to_changes(list(Added_col, col_name))
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
  capacity_max = get_meta(capacity_label,missing(capacity_max),capacity_max)
  
  # Use an empty data_list here because we want to calculate water balance
  # for the whole data set.
  # Displaying water balance can use a non empty data_list here if we want to view a subset of the data
  curr_data_list = get_data_for_analysis(data_info = list())
  
  i = 1
  join_tables = list()
  joining_columns = .self$get_joining_columns()
  
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
    
    curr_join_table = curr_data[joining_columns]
    curr_join_table[[col_name]] = water_balance_col
    join_tables[[i]] <- curr_join_table
    i = i + 1
  }
  .self$join_data(join_tables, match="first", type="full")
  .self$append_to_changes(list(Added_col, col_name))
  .self$append_to_variables(waterbalance_label, col_name)
}
)

climate_data$methods(get_summary_label = function(element="", summary_stat="", definition=list()) {
  
  if( !is_meta_data(summary_statistics_label)) {
    append_to_meta_data(summary_statistics_label,list())
  }
  
  if( !(element %in% names(meta_data[[summary_statistics_label]])) ) {
    meta_data[[summary_statistics_label]][[element]] <<- list()
  }
  
  if( !(summary_stat %in% names(meta_data[[summary_statistics_label]][[element]])) ) {
    meta_data[[summary_statistics_label]][[element]][[summary_stat]] <<- list()    
  }
  
  label = paste(element,summary_stat,length(meta_data[[summary_statistics_label]][[element]][[summary_stat]])+1)
  meta_data[[summary_statistics_label]][[element]][[summary_stat]][[label]] <<- definition
  label
}
)

climate_data$methods(get_summary_definition = function() {
  
}
)

climate_data$methods(is_definition = function(element="", summary_stat="", definition=list()) {
  
  found_match = FALSE
  if(is_meta_data(summary_statistics_label) 
      && element %in% names(meta_data[[summary_statistics_label]])
      && summary_stat %in% names(meta_data[[summary_statistics_label]][[element]]) ) {
    for(def in meta_data[[summary_statistics_label]][[element]][[summary_stat]]) {
      if(equal_lists(def, definition)) {
        found_match = TRUE
        break
      }
    }
  }
  found_match
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

get_data_start_end_dates = function(data, date_col = "Date", season_start_day = 1) {
  # TO DO better method for getting subyeary and yearly dates
  temp_start_date = doy_as_date(season_start_day,year(min(data[[date_col]])))
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

climate_data$methods(add_spell_length_col = function(col_name = "Spell Length", threshold=0.85)
{
  
  if(!is_present(spell_length_label)) {
    
    # Complete dates needed for calculations
    missing_dates_check()
  
    if(!is_present(rain_label)) stop("rain variable is required to calculate spell length")
    rain_col = .self$getvname(rain_label)
    threshold = get_meta(threshold_label, missing(threshold), threshold)
    curr_data_list = get_data_for_analysis(data_info = list())
    i = 1
    join_tables = list()
    joining_columns = .self$get_joining_columns()
    for( curr_data in curr_data_list ) {    
      curr_join_table = curr_data[joining_columns]
      curr_join_table[[col_name]] = spell_length_count(curr_data[[rain_col]], threshold)
      join_tables[[i]] <- curr_join_table
      i = i + 1
    }
    .self$join_data(join_tables, match="first", type="full")
    .self$append_to_changes(list(Added_col, col_name))
    .self$append_to_variables(spell_length_label, col_name)
  }
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

climate_data$methods(join_data = function(joining_data, match = "first", type = "full") {
  if(!is.data.frame(joining_data)) {
    if(!all(sapply(joining_data,is.data.frame))) stop("joining_data must either be a data frame or list of data frames")
    joining_data = do.call("rbind",joining_data)
  }
  .self$set_data(join(joining_data, get_data(), match=match, type=type))
}
)

climate_data$methods(get_joining_columns = function() {
  if(.self$is_meta_data(multiple_station_label) && .self$get_meta(multiple_station_label)) {
    
    joining_columns = c(.self$getvname(station_label), .self$getvname(date_label))
  }
  #TODO what to do for multiple elements
  else if (.self$is_meta_data(multiple_element_label) && .self$get_meta(multiple_element_label)) {
    joining_columns = c()
  }
  else joining_columns = .self$getvname(date_label)
}
)