\name{climate-class}
\Rdversion{1.1}
\docType{class}
\alias{climate-class}
\alias{climate}

\title{Class \code{"climate"}}
\description{
%%  ~~ A concise (1-5 lines) description of what the class is. ~~
}
\section{Extends}{

All reference classes extend and inherit methods from \code{"\linkS4class{envRefClass}"}.

}
\references{
%%  ~~put references to the literature/web site here~~
}
\author{
%%  ~~who you are~~
}
\note{
%%  ~~further notes~~
}

%% ~Make other sections like Warning with \section{Warning }{....} ~

\seealso{
%%  ~~objects to See Also as \code{\link{~~fun~~}}, ~~~
%%  ~~or \code{\linkS4class{CLASSNAME}} for links to other classes ~~~
}
\examples{
showClass("climate")
}
\keyword{classes}
\section{Fields}{
  \describe{
    \item{\code{climate_data_objects}:}{Object of class \code{list} ~~ }
    \item{\code{used_data_objects}:}{Object of class \code{list} ~~ }
    \item{\code{meta_data}:}{Object of class \code{list} ~~ }
  }
}
\section{Methods}{
  \describe{
    \item{\code{date_col_check(climate_data_objs_str, climate_data_objs_ind, date_format, convert, create)}:}{ ~~ }
    \item{\code{plot_missing_values_rain(data_list, threshold, fill_col)}:}{ ~~ }
    \item{\code{append_climate_data_objects(name, obj)}:}{ ~~ }
    \item{\code{add_to_data_info_required_variable_list(data_info, required_variable_list)}:}{ ~~ }
    \item{\code{add_to_data_info_time_period(data_info, time_period)}:}{ ~~ }
    \item{\code{add_to_data_info_merge(data_info, merged)}:}{ ~~ }
    \item{\code{create_data_info(time_period, station_list, date_list, required_variable_list)}:}{ ~~ }
    \item{\code{get_meta_data()}:}{ ~~ }
    \item{\code{get_used_data_objects()}:}{ ~~ }
    \item{\code{get_climate_data_objects(data_info)}:}{ ~~ }
    \item{\code{import_data(data_tables, data_tables_meta_data, data_tables_variables, imported_from, messages, date_format)}:}{ ~~ }
    \item{\code{initialize(data_tables, climate_obj_meta_data, data_tables_meta_data, data_tables_variables, imported_from, messages, date_format)}:}{ ~~ }
  }
}
