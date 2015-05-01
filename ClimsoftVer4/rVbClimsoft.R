

R.dataframe<-function(v1=NULL,v2=NULL){
  df<-data.frame("A" = v1, "B" = v2)
  # write.table(df,file="test2/test_vb.txt")
  return(df)
}
 plot.df <- function(df){
   png("E:/test.png")
   plot(df)
   dev.off()
 }
