\name{add_defaults_meta}
\alias{add_defaults_meta}
%- Also NEED an '\alias' for EACH other topic documented here.
\title{
%%  ~~function to do ... ~~
}
\description{
%%  ~~ A concise (1-5 lines) description of what the function does. ~~
}
\usage{
add_defaults_meta(imported_from, user)
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
        return(add_defaults("", merged))
    }
    else {
        if (!(is.null(imported_from) || imported_from == "") && 
            messages) {
            warning(paste0("The imported_from value: ", imported_from, 
                " was not recognised.\n                     Default values for variables will be used."))
        }
        if (!(threshold_label \%in\% names(merged))) 
            merged[[threshold_label]] <- 0.85
        if (!(season_start_day_label \%in\% names(merged))) 
            merged[[season_start_day_label]] <- 1
        if (!(day_start_time_label \%in\% names(merged))) 
            merged[[day_start_time_label]] <- 0
        return(merged)
    }
  }
}
% Add one or more standard keywords, see file 'KEYWORDS' in the
% R documentation directory.
\keyword{ ~kwd1 }
\keyword{ ~kwd2 }% __ONLY ONE__ keyword per line
