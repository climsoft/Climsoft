\name{ident_var}
\alias{ident_var}
%- Also NEED an '\alias' for EACH other topic documented here.
\title{
%%  ~~function to do ... ~~
}
\description{
%%  ~~ A concise (1-5 lines) description of what the function does. ~~
}
\usage{
ident_var(data, variables)
}
%- maybe also 'usage' for other objects documented here.
\arguments{
  \item{data}{
%%     ~~Describe \code{data} here~~
}
  \item{variables}{
%%     ~~Describe \code{variables} here~~
}
}
\details{
%%  ~~ If necessary, more details than the description above ~~
}
\value{
%%  ~Describe the value returned
%%  If it is a LIST, use
%%  \item{comp1 }{Description of 'comp1'}
%%  \item{comp2 }{Description of 'comp2'}
%% ...
}
\references{
%% ~put references to the literature/web site here ~
}
\author{
%%  ~~who you are~~
}
\note{
%%  ~~further notes~~
}

%% ~Make other sections like Warning with \section{Warning }{....} ~

\seealso{
%% ~~objects to See Also as \code{\link{help}}, ~~~
}
\examples{
##---- Should be DIRECTLY executable !! ----
##-- ==>  Define data, use random,
##--	or do  help(data=index)  for the standard data sets.

## The function is currently defined as
function (data, variables) 
{
    merged <- variables
    if (!(station_label \%in\% names(merged))) {
        for (label in c("Station", "station", "Station_id", "station_id", 
            "ID", "ID.")) {
            if (label \%in\% names(data)) {
                merged[[station_label]] <- label
                break
            }
        }
    }
    if (!(date_label \%in\% names(merged))) {
        for (label in c("Date", "date", "Date.D")) {
            if (label \%in\% names(data)) {
                merged[[date_label]] <- label
                break
            }
        }
    }
    if (!(date_asstring_label \%in\% names(merged))) {
        for (label in c("recorded_at", "Recorded_at")) {
            if (label \%in\% names(data)) {
                merged[[date_asstring_label]] <- label
                break
            }
        }
    }
    if (!(rain_label \%in\% names(merged))) {
        for (label in c("Rain", "rain", "Observed", "observed", 
            "Prec", "prec", "Precipitation", "Precipitation (mm)", 
            "precipitation", "precipitation (mm)")) {
            if (label \%in\% names(data)) {
                merged[[rain_label]] <- label
                break
            }
        }
    }
    if (!(year_label \%in\% names(merged))) {
        for (label in c("Year", "year", "Year.", "year.", "Year_1.")) {
            if (label \%in\% names(data)) {
                merged[[year_label]] <- label
                break
            }
        }
    }
    if (!(month_label \%in\% names(merged))) {
        for (label in c("Month", "month", "Month.", "month.", 
            "Month_1.", "Mon", "mon", "Mon.", "mon.")) {
            if (label \%in\% names(data)) {
                merged[[month_label]] <- label
                break
            }
        }
    }
    if (!(day_label \%in\% names(merged))) {
        for (label in c("Day", "day", "Day.", "day.")) {
            if (label \%in\% names(data)) {
                merged[[day_label]] <- label
                break
            }
        }
    }
    if (!(doy_label \%in\% names(merged))) {
        for (label in c("DOY", "doy", "DOY.", "doy.")) {
            if (label \%in\% names(data)) {
                merged[[doy_label]] <- label
                break
            }
        }
    }
    if (!(time_label \%in\% names(merged))) {
        for (label in c("Time", "time")) {
            if (label \%in\% names(data)) {
                merged[[time_label]] <- label
                break
            }
        }
    }
    if (!(temp_min_label \%in\% names(merged))) {
        for (label in c("Tmin", "tmin")) {
            if (label \%in\% names(data)) {
                merged[[temp_min_label]] <- label
                break
            }
        }
    }
    if (!(temp_max_label \%in\% names(merged))) {
        for (label in c("Tmax", "tmax")) {
            if (label \%in\% names(data)) {
                merged[[temp_max_label]] <- label
                break
            }
        }
    }
    return(merged)
  }
}
% Add one or more standard keywords, see file 'KEYWORDS' in the
% R documentation directory.
\keyword{ ~kwd1 }
\keyword{ ~kwd2 }% __ONLY ONE__ keyword per line
