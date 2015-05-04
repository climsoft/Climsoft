
# this function merge two vector into one data.frame 
# currently this is only a demo function to test the connectivity between R and VB.Net with R.Net for the Climsoft V4
R.dataframe<-function(v1=NULL,v2=NULL){
  df<-data.frame("A" = v1, "B" = v2)
  # write.table(df,file="test2/test_vb.txt")
  return(df)
}

# demo plot function to plot a simple scatterplot using data comming form VB.NET via R.Net
 plot.df <- function(df){
   png("E:/test.png")
   plot(df)
   dev.off()
 }
