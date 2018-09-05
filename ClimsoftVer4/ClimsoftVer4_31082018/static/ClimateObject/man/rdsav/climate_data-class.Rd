\name{climate_data-class}
\Rdversion{1.1}
\docType{class}
\alias{climate_data-class}
\alias{climate_data}

\title{Class \code{"climate_data"}}
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
showClass("climate_data")
}
\keyword{classes}
\section{Fields}{
  \describe{
    \item{\code{data}:}{Object of class \code{data.frame} ~~ }
    \item{\code{split_data}:}{Object of class \code{list} ~~ }
    \item{\code{meta_data}:}{Object of class \code{list} ~~ }
    \item{\code{variables}:}{Object of class \code{list} ~~ }
    \item{\code{changes}:}{Object of class \code{list} ~~ }
    \item{\code{data_time_period}:}{Object of class \code{character} ~~ }
    \item{\code{is_data_split}:}{Object of class \code{logical} ~~ }
  }
}
\section{Methods}{
  \describe{
    \item{\code{add_doy_col(YearLabel, DOYLabel, SeasonLabel, DOSLabel)}:}{ ~~ }
    \item{\code{add_year_month_day_cols(date_format, YearLabel, MonthLabel, DayLabel)}:}{ ~~ }
    \item{\code{date_col_check(date_format, convert, create, messaging)}:}{ ~~ }
    \item{\code{check_split_data()}:}{ ~~ }
    \item{\code{check_multiple_data()}:}{ ~~ }
    \item{\code{is_meta_data(str)}:}{ ~~ }
    \item{\code{is_present(str, require_all)}:}{ ~~ }
    \item{\code{append_to_changes(value)}:}{ ~~ }
    \item{\code{append_to_variables(name, value)}:}{ ~~ }
    \item{\code{append_to_meta_data(name, value)}:}{ ~~ }
    \item{\code{replace_column_in_data(col_name, column_data)}:}{ ~~ }
    \item{\code{append_column_to_data(column_data, col_name)}:}{ ~~ }
    \item{\code{set_data_time_period(new_data_time_period)}:}{ ~~ }
    \item{\code{set_changes(new_changes)}:}{ ~~ }
    \item{\code{set_variables(new_variables)}:}{ ~~ }
    \item{\code{set_meta(new_meta)}:}{ ~~ }
    \item{\code{set_data(new_data, messages)}:}{ ~~ }
    \item{\code{get_meta(label, overrider)}:}{ ~~ }
    \item{\code{get_data_time_period()}:}{ ~~ }
    \item{\code{get_changes()}:}{ ~~ }
    \item{\code{getvname(label)}:}{ ~~ }
    \item{\code{get_variables()}:}{ ~~ }
    \item{\code{get_data_for_analysis(data_info)}:}{ ~~ }
    \item{\code{get_data()}:}{ ~~ }
    \item{\code{initialize(data, data_name, meta_data, variables, data_time_period, imported_from, messages, identify_variables, start_point, check_dates, date_format)}:}{ ~~ }
  }
}
