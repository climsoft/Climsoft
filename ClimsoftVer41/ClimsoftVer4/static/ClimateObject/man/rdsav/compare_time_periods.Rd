\name{compare_time_periods}
\alias{compare_time_periods}
%- Also NEED an '\alias' for EACH other topic documented here.
\title{
%%  ~~function to do ... ~~
}
\description{
%%  ~~ A concise (1-5 lines) description of what the function does. ~~
}
\usage{
compare_time_periods(desired_time_period, data_time_period)
}
%- maybe also 'usage' for other objects documented here.
\arguments{
  \item{desired_time_period}{
%%     ~~Describe \code{desired_time_period} here~~
}
  \item{data_time_period}{
%%     ~~Describe \code{data_time_period} here~~
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
function (desired_time_period, data_time_period) 
{
    out = FALSE
    if (desired_time_period == yearly_label) 
        out = TRUE
    else if (desired_time_period == subyearly_label) {
        if (data_time_period != yearly_label) 
            out = TRUE
    }
    else if (desired_time_period == daily_label) {
        if (data_time_period == subdaily_label | data_time_period == 
            daily_label) 
            out = TRUE
    }
    else if (desired_time_period == subdaily_label) {
        if (data_time_period == subdaily_label) 
            out = TRUE
    }
  }
}
% Add one or more standard keywords, see file 'KEYWORDS' in the
% R documentation directory.
\keyword{ ~kwd1 }
\keyword{ ~kwd2 }% __ONLY ONE__ keyword per line
