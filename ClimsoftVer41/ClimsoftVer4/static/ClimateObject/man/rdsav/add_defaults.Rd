\name{add_defaults}
\alias{add_defaults}
%- Also NEED an '\alias' for EACH other topic documented here.
\title{
%%  ~~function to do ... ~~
}
\description{
%%  ~~ A concise (1-5 lines) description of what the function does. ~~
}
\usage{
add_defaults(imported_from, user)
}
%- maybe also 'usage' for other objects documented here.
\arguments{
  \item{imported_from}{
%%     ~~Describe \code{imported_from} here~~
}
  \item{user}{
%%     ~~Describe \code{user} here~~
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
function (imported_from, user) 
{
    merged <- user
    if (!is.null(imported_from) && imported_from == "CLIMSOFT") {
        if (!(date_asstring_label \%in\% names(merged))) 
            merged[[date_asstring_label]] <- "Recorded_at"
        if (!(rain_label \%in\% names(merged))) 
            merged[[rain_label]] <- "Observed"
        return(add_defaults("", merged))
    }
    else {
        if (!(is.null(imported_from) || imported_from == "") && 
            messages) {
            warning(paste0("The imported_from value: ", imported_from, 
                " was not recognised.\n                          Default values for variables will be used."))
        }
        if (!(station_label \%in\% names(merged))) 
            merged[[station_label]] <- "Station"
        if (!(date_label \%in\% names(merged))) 
            merged[[date_label]] <- "Date"
        if (!(date_asstring_label \%in\% names(merged))) 
            merged[[date_asstring_label]] <- "Date as string"
        if (!(rain_label \%in\% names(merged))) 
            merged[[rain_label]] <- "Rain"
        if (!(year_label \%in\% names(merged))) 
            merged[[year_label]] <- "Year"
        if (!(season_label \%in\% names(merged))) 
            merged[[season_label]] <- merged[[year_label]]
        if (!(month_label \%in\% names(merged))) 
            merged[[month_label]] <- "Month"
        if (!(day_label \%in\% names(merged))) 
            merged[[day_label]] <- "Day"
        if (!(doy_label \%in\% names(merged))) 
            merged[[doy_label]] <- "DOY"
        if (!(dos_label \%in\% names(merged))) 
            merged[[dos_label]] <- merged[[doy_label]]
        if (!(time_label \%in\% names(merged))) 
            merged[[time_label]] <- "Time"
        if (!(temp_min_label \%in\% names(merged))) 
            merged[[temp_min_label]] <- "Temp min"
        if (!(temp_max_label \%in\% names(merged))) 
            merged[[temp_max_label]] <- "Temp max"
        if (!(evaporation_label \%in\% names(merged))) 
            merged[[evaporation_label]] <- "Evaporation"
        return(merged)
    }
  }
}
% Add one or more standard keywords, see file 'KEYWORDS' in the
% R documentation directory.
\keyword{ ~kwd1 }
\keyword{ ~kwd2 }% __ONLY ONE__ keyword per line
