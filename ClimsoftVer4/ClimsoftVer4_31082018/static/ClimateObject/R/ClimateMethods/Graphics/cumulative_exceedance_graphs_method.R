# CUMULATIVE GRAPH and EXCEEDANCE GRAPH
#' @title plot cumulative and exceedance graphs
#' @name cumulative_exceedance_graphs
#' @author Fanuel 2015 (AMI)

#' @description \code{cumulative_exceedance_graphs} 
#' Enables plotting cumulative and exceedance graphs given a climate object

#' @return cumulative graph or exceedance graph. the default is cumulative graph


climate$methods(cumulative_exceedance_graphs = function(data_list=list(),interest_var = "Total Rain",cumulative_graph =TRUE, legend_bty="n",
                                                        color=rainbow(12),percent=TRUE, main="", xlabel="",ylabel="",line_type="o",
                                                        convert=TRUE, data_period_label=yearly_label, legend_position="center",
                                                        legend_label=c("plot1","plot2"),station_name=TRUE, plot_window=FALSE,gpar=par(mfrow=c(2,4)),
                                                        grid_sq=TRUE, nx=5, ny=nx,lwd=2,pch=21,box.lty=par("lty"))
{  
  
  if (!is.list(interest_var)){
    interest_var=as.list(interest_var)
  }
  data_list=add_to_data_info_required_variable_list(data_list, interest_var) 
  
  data_list=add_to_data_info_time_period(data_list, data_period_label)
  
  data_list=c(data_list,convert_data=convert)
  
  climate_data_objs_list = get_climate_data_objects(data_list)
  
  for(data_obj in climate_data_objs_list) {
    
    if (station_name){    
      data_name = data_obj$get_meta(data_name_label)
    }else {
      data_name=NULL
    }
    
    # Access data in methods
    curr_data_list = data_obj$get_data_for_analysis(data_list)
    
    #-----------------------------------------------------------------------------------#
    
    for( curr_data in curr_data_list ) {
      #---------------------------------------------------------------------------------#
      
      sort_col <- list()
      
      prop_col <- list()
      
      cum_perc_col <- list()
      
      exceedance_col <- list()
      
      exceedance_prop <- list()
      
      for (i in 1:length(interest_var)) {
        
        interest_col=data_obj$getvname(interest_var[[i]])
        
        # sort the data
        sort_col[[i]]=sort(curr_data[[interest_col]])
        #---------------------------------------------------------------------------------#
        #calculate the proportions
        #---------------------------------------------------------------------------------#      
        prop_col[[i]]=(1:length(sort_col[[i]]))/length(sort_col[[i]])
        
        if (percent == TRUE){     
          #--------------------------------------------------------------------------------#
          
          #calculate the percentage of the cumulative proportions
          #--------------------------------------------------------------------------------#
          cum_perc_col[[i]]= prop_col[[i]]*100 
          #------------------------------------------------------------------------------
          #=====Add the values for plotting the exceedance graph==========================
          #--------------------------------------------------------------------------------#
          exceedance_col[[i]]=100-cum_perc_col[[i]]        
        }else {
          
          #Values for exceedance graph using the probabilities     
          exceedance_prop[[i]]=1-prop_col[[i]] 
        }
      }
      
      if (plot_window){
        par=gpar
      }       
      #====Plotting the cumulative graph when true=====================================
      #----------------------------------------------------------------------------------#
      if(cumulative_graph){
        par(new=FALSE)
        for (i in 1:length(sort_col)){
          #--------------------------------------------------------------------------------#
          if (main==""){
            main="cumulative graph"
          }
          if (xlabel==""){
            xlabel= "Variable of interest"
          }
          #====Plotting the cumulative================================================
          if (percent ==TRUE){
            
            if (ylabel==""){
              ylabel= "Percent of years" 
            }
            plot(sort_col[[i]], cum_perc_col[[i]],
                 main=c(data_name,main), xlab=xlabel, ylab=ylabel,type=line_type, col=color[i],
                 xlim=range(sort_col),ylim=range(cum_perc_col),pch=pch)
          }else{
            if (ylabel==""){
              ylabel= " Proportion of days" 
            }
            plot(sort_col[[i]], prop_col[[i]],main=c(data_name,main), xlab=xlabel, 
                 ylab=ylabel,type=line_type, col=color[i],
                 xlim=range(sort_col),ylim=range(prop_col),pch=pch)
          }
          par(new=TRUE)
        }
        if(grid_sq==TRUE){
          grid(nx, ny, lwd = lwd)
        }
      }else{
        par(new=FALSE)
        #====Plotting the exceedance graph  when true======================================== 
        for (i in 1:length(sort_col)){
          #--------------------------------------------------------------------------------#
          if (main==""){
            main="Exceedance graph"
          }
          if (xlabel==""){
            xlabel= "Variable of interest"
          }
          if(percent == TRUE){
            # Plotting the exceedance graph
            if (ylabel==""){
              ylabel= " Percent of years" 
            }
            plot(sort_col[[i]], exceedance_col[[i]],xlab=xlabel,ylab=ylabel,xlim=range(sort_col),
                 ylim=range(exceedance_col),col=color[i], main=c(data_name,main),type=line_type,pch=pch)
            #         par(new=TRUE)
          }else{
            if (ylabel==""){
              ylabel= " Proportion of days" 
            }
            plot(sort_col[[i]], exceedance_prop[[i]],xlab=xlabel,ylab=ylabel,xlim=range(sort_col),
                 ylim=range(exceedance_prop),col=color[i],main=c(data_name,main),type=line_type,pch=pch)            
          }
          par(new=TRUE) 
        }
        if(grid_sq==TRUE){
          grid(nx, ny, lwd = lwd)
        } 
      }      
      if (length(interest_var)>1){
        legend(legend_position,legend_label,fill = color, bty = legend_bty,box.lty=box.lty)
      }
    }    
  }
  par(mfrow=c(1,1))
}
)