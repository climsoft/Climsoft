# Defining the reference class "climate"
# This reference class can contain multiple climate_data objects
# The fields are the properties every climate_data object will have.

# climate_data_objects : A list of climate_data objects
# used_data_tables     : A list of extra climate_data objects, created during use
# meta_data            : Any information about the climate object. e.g. "name"


climate <- setRefClass("climate", 
                            fields = list(climate_data_objects = "list", used_data_objects = "list", 
                                          meta_data = "list")
)

# INITIALIZE method
##############################################################################################
# Functions of reference classes are called methods.
# This is how you define a method for a specific reference class.
# Every reference class has an initialize method which tells R how to create new 
# climate objects.
# By the end of this method, all fields of climate_data should be defined.
# Notice that we don't have a climate object as an input.
# We can refer to any field of a climate_data object by name. e.g. climate_data_objects

# data_tables           : list of data.frames - each one will be used to create a climate_data
#                         object
# data_tables_meta_data : list of meta_data lists - one for each data.frame
# data_tables_variables : list of variables lists - one for each data.frame
# climate_obj_meta_data : the meta_data for the climate object
# imported_from         : list of strings telling us where the data has come from
#                         - one for each data.frame                         

climate$methods(initialize = function(data_tables = list(), climate_obj_meta_data = list(), 
                                      data_tables_meta_data = rep(list(list()),length(data_tables)),
                                      data_tables_variables = rep(list(list()),length(data_tables)), 
                                      imported_from = as.list(rep("",length(data_tables))),
                                      data_time_periods = as.list(rep("daily",length(data_tables))),
                                      messages=TRUE, convert=TRUE, create=TRUE,
                                      date_formats = as.list(rep("%d/%m/%Y",length(data_tables))))
{

  meta_data <<- climate_obj_meta_data
  used_data_objects <<- list()
  
  if (missing(data_tables) || length(data_tables) == 0) {
    climate_data_objects <<- list()
  }
  
  else {
    .self$import_data(data_tables=data_tables,data_tables_meta_data=data_tables_meta_data, data_tables_variables=data_tables_variables, 
                      imported_from=imported_from, data_time_periods=data_time_periods, messages=messages, convert=convert, create=create,
                      date_formats=date_formats)
  }
  
}
)

# IMPORT DATA FUNCTION
##############################################################################################

climate$methods(import_data = function(data_tables = list(), data_tables_meta_data = rep(list(list()),length(data_tables)),
                                       data_tables_variables = rep(list(list()),length(data_tables)), 
                                       imported_from = as.list(rep("",length(data_tables))), 
                                       data_time_periods = as.list(rep("daily",length(data_tables))),
                                       messages=TRUE, convert=TRUE, create=TRUE, 
                                       date_formats = as.list(rep("%d/%m/%Y",length(data_tables))))
{

  if (missing(data_tables) || length(data_tables) == 0) {
    stop("No data found. No climate_data objects can be created.")
  }
  
  else {
    
    if ( ! (class(data_tables) == "list") )  {
      stop("data_tables must be a list of data frames")
    }
    
    if (length(unique(names(data_tables))) != length(names(data_tables)) ) {
      stop("There are duplicate names in the data tables list.")
    }
    
    if ( !(length(data_tables_meta_data) == length(data_tables)) ) { 
      stop("If data_tables_meta_data is specified, it must be a list of meta_data lists with the same
           length as data_tables.")
    }
    
    if ( !(length(data_tables_variables) == length(data_tables)) ) { 
      stop("If data_tables_variables is specified, it must be a list of variables lists with the same
           length as data_tables.")
    }
    
    if ( !(class(imported_from) == "list") || ! (length(imported_from) == length(data_tables))  ) { 
      stop("imported_from must be a list of the same length as data_tables")
    }
    
    if ( !(class(data_time_periods) == "list") || ! (length(data_time_periods) == length(data_tables))  ) { 
      stop("data_time_periods must be a list of the same length as data_tables")
    }

    if ( !(class(date_formats) == "list") || ! (length(date_formats) == length(data_tables))  ) { 
      stop("date_formats must be a list of the same length as data_tables")
    }
    # loop through the data_tables list and create a climate_data object for each
    # data.frame given
    
    new_climate_data_objects = list()
    
    for ( i in (1:length(data_tables)) ) {
      
      new_data = climate_data$new(data=data_tables[[i]], data_name = names(data_tables)[[i]], 
                                  meta_data = data_tables_meta_data[[i]], variables = data_tables_variables[[i]], 
                                  imported_from = imported_from[[i]], 
                                  data_time_period = data_time_periods[[i]], start_point = i, 
                                  messages = messages, convert = convert, create = create,
                                  date_format = date_formats[[i]])
      
      # Add this new climate_data object to our list of climate_data objects
      .self$append_climate_data_objects( new_data$meta_data[[data_name_label]],new_data)
      
    }
  }
}
)
#TODO this is just a temporary function for abib to use while we understand the clidata formate
climate$methods(import_clidata = function(data_table, dataname="Clidata")
{

  temp<-melt(data_table,id=1:5,variable.name="Day",value.name="Rain")
  temp$Day= as.numeric(substr(temp$Day, 4, 5))

  #---------------------------------------------------------#
  # And write to climate data object
  #---------------------------------------------------------#
  new_data = climate_data$new(data=temp, data_name = dataname)
  
  # Add this new climate_data object to our list of climate_data objects
  .self$append_climate_data_objects( new_data$meta_data[[data_name_label]],new_data)
  
}
)

# Getter methods
###############################################################################################
# We can create methods to extract fields from a climate_data object.
# These are called getter methods and are usually very simple functions.
# Notice that no input is needed.

# get_climate_data_objects returns some of the climate_data objects in the climate object
# It will also create new ones if needed
# Specification by data_info

climate$methods(get_climate_data_objects = function(data_info= list()) {
  
  climate_data_list = list()

  if(time_period_label %in% names(data_info) ) {
    time_period=data_info[[time_period_label]]
  } else {
    time_period="any"
  } 

  for (temp in climate_data_objects) {
    name = temp$meta_data[[data_name_label]]
    if (time_period==temp$data_time_period||time_period=="any"){
      if (required_variable_list_label %in% names(data_info)){
        if (!temp$is_present(data_info[[required_variable_list_label]])){
          next
        }
      }
      climate_data_list[[name]] <- temp 
    }
    else if (convert_data_label %in% names(data_info)){
      if (data_info[[convert_data_label]]){
        if(compare_time_periods(time_period,temp$data_time_period)){
          # Check if needs to be created first.
          summary_created = FALSE
          for(used_obj in used_data_objects) {
            if(used_obj$is_meta_data(summarized_from_label) 
               && used_obj$get_meta(summarized_from_label) == name 
               && used_obj$data_time_period == time_period) {
              summarized_name = used_obj$get_meta(data_name_label)
              if (required_variable_list_label %in% names(data_info)){
                if (!used_obj$is_present(data_info[[required_variable_list_label]])){
                  next
                }
              }
              climate_data_list[[summarized_name]] <- used_obj
              summary_created = TRUE
              break
            }
          }
          if(!summary_created) {
            temp_summarized <- temp$summarize_data(time_period, start_point = length(used_data_objects)+1)
            name = temp_summarized$meta_data[[data_name_label]]
            .self$append_used_data_objects(name, temp_summarized)
            if (required_variable_list_label %in% names(data_info)){
              if (!temp_summarized$is_present(data_info[[required_variable_list_label]])){
                next
              }
            }
            climate_data_list[[name]] <- temp_summarized 
          }
        }
      }
    }
    #TO DO think hard whether we should restrict based on stations or not my inclination is not at the data object level.
  }
  #TODO Merge within Time tevels when any is selected.
  if (merge_data_label %in% names(data_info)){
    if (data_info[[merge_data_label]]){
      if (length(climate_data_list)>1){
        merge_obj <- .self$merge_vertical(climate_data_list)
        name = merge_obj$meta_data[[data_name_label]]
        climate_data_list <- list()
        climate_data_list[[name]] <- merge_obj 
      }
    }
  }

  return(climate_data_list)
  
}
)

climate$methods(get_used_data_objects = function() {
  return(used_data_objects)
}
)

climate$methods(get_meta_data = function() {
  return(meta_data)
}
)

# Create and edit data info methods
###############################################################################################
climate$methods(create_data_info = function(time_period="", station_list="", date_list="", required_variable_list="") {
  data_info=list()
  if (!missing(time_period)){
    #TO DO check that it is a valid time period
    data_info[[time_period_label]] <- time_period
  }
  if (!missing(station_list)){
    #TO DO check that it is valid 
    data_info[[station_list_label]] <- station_list
  }
  if (!missing(date_list)){
    #TO DO check that it is valid 
    data_info[[date_list_label]] <- date_list
  }
  if (!missing(required_variable_list)){
    #TO DO check that it is valid 
    data_info[[required_variable_list_label]] <- required_variable_list
  }
  
  return (data_info)
}
)

climate$methods(add_to_data_info_merge = function(data_info=list(), merged=FALSE) {
  if (merge_data_label %in% names(data_info)){
    if (data_info[[merge_data_label]]!=merged & !missing(merged)){
      warning ("overwriting user choice for merging data")
      data_info[[merge_data_label]]<-merged
    }
  }
  else data_info[[merge_data_label]]<-merged
  return (data_info)
}
)

climate$methods(add_to_data_info_time_period = function(data_info=list(), time_period="") {
  if (time_period_label %in% names(data_info)){
    if (data_info[[time_period_label]]!=time_period & !missing(time_period)){
      warning ("overwriting user choice for time period")
      data_info[[time_period_label]]<-time_period
    }
  }
  else data_info[[time_period_label]]<-time_period
  return (data_info)
}
)

climate$methods(add_to_data_info_required_variable_list = function(data_info=list(), required_variable_list="") {
  if (!missing(required_variable_list)){
    #TO DO check required_variable_list is valid
    if (required_variable_list_label %in% names(data_info)){
      data_info[[required_variable_list_label]]<-c(data_info[[required_variable_list_label]],required_variable_list) #TO DO Check what happens to repeats 
    }
    else data_info[[required_variable_list_label]]<-required_variable_list
  }
  return (data_info)
}
)

#TO DO other creat and add methods

# Append methods
###############################################################################################
climate$methods(append_climate_data_objects = function(name, obj) {
  if( !class(name) == "character") {
    stop("name must be a character")
  }
  
  if ( !class(obj) == "climate_data") {
    stop("obj must be a climate_data object")
  }

  climate_data_objects[[name]] <<- obj
}
)

climate$methods(append_used_data_objects = function(name, obj) {
  if( !class(name) == "character") {
    stop("name must be a character")
  }
  
  if ( !class(obj) == "climate_data") {
    stop("obj must be a climate_data object")
  }
  
  used_data_objects[[name]] <<- obj
}
)

# is_present_or_meta can check if a given variable name (or list of variable names) is in the data.frame or the meta_data or neither.
# This will be used by other functions particularly related to station level data such as latitude, longditude etc. 
# TO DO check functionality for missing cols and if there are multiple elements in long format (currently will return true even if there are no instances possibly correct as like returning true when all values are missing?)

climate$methods(is_present_or_meta = function(str, require_all=TRUE, require_in_all=TRUE) {
  out = FALSE
  for (temp in climate_data_objects) {
    out=temp$is_present_or_meta(str,require_all)
    if (require_in_all) if (!out) break
    if (!require_in_all) if (out) break
  }
  return(out)
}
)


# Other methods
#############################################################################################
# All analysis functions will be methods of climate objects and NOT climate_data objects.
# This is because we can call the method once to do the calculations on multiple data.frames
# at the same time.
# All these methods will allow the user to specify which climate_data objects they want
# to do the analysis on.



  #------------------------------------------------------------------------
  # This function plots the missing values for the rainfall amount, per year
  # It is here to demonstrate how an output method 
  #
  # It has the following optional arguments:
  # data_list: Specify the subset of the data to use. 
  # threshold: threshold which determines if a day is dry if the rainfall amount is below it. This overrides the threshold stored in the metadata if provided.
  # fill_col: A list of colours to use the first is for rain days the second for dry and the third for missing, missing dates are blank
  # 
  # ----------------------------------------------------------------------------

climate$methods(plot_missing_values_rain = function(data_list=list(), threshold = 0.85, fill_col=c("blue","yellow","red"))
{    
  # get_climate_data_objects returns a list of the climate_data objects specified
  # in the arguements.
  # If no objects specified then all climate_data objects will be taken by default
  # TO DO have options such as colours and the rest
  data_list=add_to_data_info_required_variable_list(data_list, list(rain_label))
  data_list=add_to_data_info_time_period(data_list, daily_label)
  climate_data_objs_list = get_climate_data_objects(data_list)
  
  for(data_obj in climate_data_objs_list) {
    curr_threshold = data_obj$get_meta(threshold_label,threshold)
    
    rain_col  = data_obj$variables[[rain_label]]
    # If doy or year column is not in the data frame, create it.
    if ( !(data_obj$is_present(dos_label)&data_obj$is_present(season_label))) {
      # add_doy_col function does not exist yet.
      data_obj$add_doy_col()
    }
    dos_col = data_obj$variables[[dos_label]]
    season_col = data_obj$variables[[season_label]]
    curr_data_list=data_obj$get_data_for_analysis(data_list)
    
    for( curr_data in curr_data_list ) {
      a2<-subset(curr_data, curr_data[[rain_col]] > curr_threshold)
      a3<-subset(curr_data, curr_data[[rain_col]] <= curr_threshold)
      a1<-curr_data[is.na(curr_data[[rain_col]]),]
      #plot2<-plot.new()

      plot(curr_data[[season_col]],curr_data[[dos_col]], ylim=c(0,500), log = "", asp = NA, xlab="Year",ylab="Day of Year", main="Rain Present")
      #plot.window(xlim=c(min(curr_data[[season_col]]),max(curr_data[[season_col]])),ylim=c(0,500), log = "", asp = NA) #TO DO Tidy up graphical parameters
      #title(xlab="Year",ylab="Day of Year", main="Rain Present") #TO DO Need to think hard about how display name are stored
      legend("topright",c("Rain","Dry","NA"),fill=fill_col,horiz=TRUE)
      points(as.numeric(a1[[season_col]]),a1[[dos_col]],pch="-",col=fill_col[3])
      points(as.numeric(a2[[season_col]]),a2[[dos_col]],pch="-",col=fill_col[1])
      points(as.numeric(a3[[season_col]]),a3[[dos_col]],pch="-",col=fill_col[2])
      
      # TO DO output multiple plots in multiple ways
      #plot2
    }
  }
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


climate$methods(date_col_check = function(data_list=list(), date_format = "%d/%m/%Y", convert = TRUE,
                                          create = TRUE) 
{
  
  climate_data_objs = get_climate_data_objects(data_list)
  
  for(data_obj in climate_data_objs){
    data_obj$date_col_check(date_format= date_format, convert=convert, create=create)
    
  }
}
)

climate$methods(merge_vertical = function(climate_data_objs = climate_data_objects,
                                          identifier = "Identifier", merge_name = "") 
{

  # TO DO: should argument be data_list instead of climate_data_objs?
  #        do we allow to merge subsets of the data or only whole data objects?
  #        what meta data should be stored in the merged data object so it can be
  #        uniquiely identified later.
  
  
  if(length(climate_data_objs) == 0) {
    stop("No climate_data objects have been given to merge.")
  }
  
  time_periods = list()
  for(data_obj in climate_data_objs) {
    time_periods = c(time_periods,data_obj$data_time_period)
  }
  
  if(length(unique(time_periods)) != 1) {
    stop("Cannot merge data sets that are using different time periods.")
  }
  
  merge_time_period = time_periods[[1]]
  
  for(used_obj in used_data_objects) {
    if(merge_time_period == used_obj$data_time_period && used_obj$is_meta_data(merged_from_label)
      && length(used_obj$meta_data[[merged_from_label]]) == length(names(climate_data_objs))
      && length(union(used_obj$meta_data[[merged_from_label]], names(climate_data_objs))) == length(names(climate_data_objs)) ) {
        return(used_obj)
    }
  }
  
  # identified_variables : data frame showing which recognised variables are in each data set
  identified_variables = data.frame(data_object=names(climate_data_objs))

  # vars : the list of variables found in the variables list for data objects
  #       some of these variables may not actually be in the data set
  vars = list()
  
  for(data_obj in climate_data_objs) {
    vars = c(vars,names(data_obj$variables))
  }
  vars = unique(vars)
  
  # used_vars : the subset of vars containing only the variables that appear in at least 
  #             one of the data sets
  used_vars = list()
  vars_names = list()
  
  for(curr_var in vars) {

    new_col = c()
    
    # new_col : logical vector showing which data sets contain curr_var
    for(data_obj in climate_data_objs) {    
      new_col = c(new_col,data_obj$is_present(curr_var))
      if( data_obj$is_present(curr_var) && !(curr_var %in% names(vars_names)) ) {
        vars_names[[curr_var]] <- data_obj$getvname(curr_var)
      }
    }
    
    # We are only interested in variables that appear in at least 1 data set
    if(sum(new_col) >= 1) {
      
      # Add new_col to identified_variables data frame
      identified_variables[,curr_var] = new_col
      used_vars = c(used_vars, curr_var)
    }
  }
  
  #######################################################################

  i = 1
  data_to_merge = list()
  for(data_obj in climate_data_objs) {
    
    curr_data_list = data_obj$get_data_for_analysis(data_info = list())
    
    for(curr_data in curr_data_list ) {
      
      if(identifier %in% names(curr_data)) {
        stop(paste0("There is already a column in: '", data_obj$get_meta("data_name"), "' with name: '",
                    identifier,"'. The identifier cannot be an exisiting column name."))
      }
      
      # Add an identifier column to each data set containing the data object name
      data_name = data_obj$get_meta(data_name_label)
      curr_data[[identifier]] <- rep(data_name,nrow(data_obj$data))
      date_col = vars_names[[date_label]]
      
      for(var_name in used_vars) {
        # The same variable may have different names in different data sets
        # so we rename these columns to be the same in each data set.
        if(identified_variables[i,var_name]) {
          old_col_name = data_obj$getvname(var_name)
          names(curr_data)[names(curr_data) == old_col_name] <- vars_names[[var_name]]
        }
    
        # If the variable is not present, but can be generated from other columns
        # create that column. e.g. year can be created from date column
          
        else if( var_name == year_label ) {
          year_col = vars_names[[var_name]]
          curr_data[[var_name]] <- year(curr_data[[date_col]])
        }
    
        else if( var_name == month_label ) {
          month_col = vars_names[[var_name]]
          curr_data[[var_name]] <- month(curr_data[[date_col]])
        }
    
        else if( var_name == day_label ) {
          day_col = vars_names[[var_name]]
          curr_data[[var_name]] <- day(curr_data[[date_col]])
        }
          
      }
    data_to_merge[[length(data_to_merge)+1]] <- curr_data
    }
    i = i + 1
  }
  merge_data = rbind.fill(data_to_merge)

  merged_obj = climate_data$new(data = merge_data, data_name = merge_name, start_point = length(used_data_objects)+1,
                                  data_time_period = merge_time_period, check_missing_dates=FALSE)
    
  merged_obj$append_to_meta_data(merged_from_label, names(climate_data_objs))
    
  .self$append_used_data_objects(merged_obj$meta_data[[data_name_label]],merged_obj)
  
  # return the merged object
  used_data_objects[[ merged_obj$get_meta(data_name_label) ]]

}
)

climate$methods(get_summary_name = function(time_period, data_obj) 
{
  if(missing(time_period)) {
    stop("Specify the time period of the summarized data.")
  }
  
  data_name = data_obj$get_meta_new(data_name_label)
  
  if(compare_time_periods(time_period,data_obj$data_time_period)) {
    # Check if needs to be created first.
    summary_created = FALSE
    for(used_obj in used_data_objects) {
      if(used_obj$is_meta_data(summarized_from_label) 
         && used_obj$get_meta(summarized_from_label) == data_name
         && used_obj$data_time_period == time_period) {
        summarized_obj = used_obj
        summary_created = TRUE
        break
      }
    }
    
    if(!summary_created) {
      summarized_obj <- data_obj$summarize_data(time_period, start_point = length(used_data_objects)+1)
      name = summarized_obj$meta_data[[data_name_label]]
      .self$append_used_data_objects(name, summarized_obj)
    }
#    return(summarized_obj$meta_data[[data_name_label]])
    return(summarized_obj)
  }
  
  else stop("Cannot create a summary for these time periods.")
    
}
)

climate$methods(append_to_summary = function(time_period, data_obj, col_data, col_name="", label,
                                             replace=FALSE)
{
  if(missing(time_period)) {
    stop("Specify the time period of the summarized data.")
  }
  
  if(missing(col_data)) {
    stop("Specify the data to be added to the summary data.")
  }
  
  data_name = data_obj$get_meta_new(data_name_label)
  
  if(compare_time_periods(time_period,data_obj$data_time_period)) {
    # Check if needs to be created first.
    summary_created = FALSE
    for(used_obj in used_data_objects) {
      if(used_obj$is_meta_data(summarized_from_label) 
         && used_obj$get_meta(summarized_from_label) == data_name
         && used_obj$data_time_period == time_period) {
        summarized_obj = used_obj
        summary_created = TRUE
        break
      }
    }
    
    if(!summary_created) {
      summarized_obj <- data_obj$summarize_data(time_period, start_point = length(used_data_objects)+1)
      name = summarized_obj$meta_data[[data_name_label]]
      .self$append_used_data_objects(name, summarized_obj)
    }

    if( !missing(label) && summarized_obj$is_present(label) ) {
      if(replace) {
        col_name = summarized_obj$getvname(label)
        message(paste0("Replacing column ", col_name, " with the new data."))
        summarized_obj$replace_column_in_data(col_name, col_data)
      }
      else message(paste("A column named ",col_name,"already exists. It will not be replaced.
                         To replace this column, re run the method and specify replace = TRUE."))
    }
    
    else {
      if(missing(label)) summarized_obj$append_column_to_data(col_data,col_name)
      else summarized_obj$append_column_to_data(col_data,col_name, label)
    }
  }
  else stop(paste0(data_name, " cannot be summarized to ",time_period,"."))

  
}
)

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

climate$methods(display_water_balance = function(data_list = list(), print_tables = TRUE, col_name = "Water Balance",
                                                 capacity_max = 100, evaporation = 5, decimal_places = 0, 
                                                 months_list = month.abb, day_display = "Day")
{
  
  # rain required
  data_list=add_to_data_info_required_variable_list(data_list, list(rain_label))
  
  # date period is "daily"
  data_list=add_to_data_info_time_period(data_list, daily_label)
  climate_data_objs = get_climate_data_objects(data_list)
  
  for(data_obj in climate_data_objs) {
    
    # check if the waterbalance column is present
    if( !(data_obj$is_present(waterbalance_label)) ) {
      # If not, add the column
      if(missing(capacity_max)) {
        data_obj$add_water_balance_col(col_name=col_name,evaporation=evaporation)
      }
      else { data_obj$add_water_balance_col(col_name,capacity_max,evaporation) }
    }
    
    # Do this after if to save repeating 
    waterbalance_col = data_obj$getvname(waterbalance_label)
    
    # Must add these columns if not present to display this way
    if( !(data_obj$is_present(year_label) && data_obj$is_present(month_label) && data_obj$is_present(day_label)) ) {
      data_obj$add_year_month_day_cols()
    }
    
    year_col = data_obj$getvname(year_label)
    month_col = data_obj$getvname(month_label)
    day_col = data_obj$getvname(day_label)
    
    # This is always how we access data in methods now.
    curr_data_list = data_obj$get_data_for_analysis(data_list)
    
    for( curr_data in curr_data_list ) {
      
      # Added extra argument decimal_places to allow flexibility
      curr_data[[waterbalance_col]] <- round(curr_data[[waterbalance_col]], digits = decimal_places)
      
      
      # initialize list of tables
      tables = list()
      
      # Split curr_data into single data frames for each year
      # It returns a list of data.frames, split by year 
      # This is much faster (6x faster when I checked) than subsetting
      # Split is not always appropriate but it is in this case
      years_split <- split(curr_data, list(as.factor(curr_data[[year_col]])))
      
      # counter to use in the loop
      i = 1
      
      # loop through the split data frames 
      for ( single_year in years_split ) {
        
        # Make data into table - rows:days, columns:months, values:water balance
        tables[[i]] <- dcast(single_year, single_year[[ day_col ]]~single_year[[ month_col ]], value.var = waterbalance_col)
        
        # Rename columns
        # Added day_display and months_list as extra arguments so it is more flexible
        
        end = length(colnames(tables[[i]]))
        names(tables[[i]])[ 1 ] <- day_display
        colnames(tables[[i]])[2:end] <- months_list[1:end-1]
        i = i + 1
      }
      
      # The names of years_split is the list of years as strings.
      # These are better labels than numbers so they can be identified better
      names(tables) <- names(years_split)
    }
    
    # Only print if requested
    if(print_tables) {print(tables)}
    
    # Always return the tables list
    # If we don't return and don't print then the method does nothing!
    return(tables)
    
  }
  
}
)
