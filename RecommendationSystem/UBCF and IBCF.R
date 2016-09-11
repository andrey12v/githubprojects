library(recommenderlab) 
library(reshape2)  
library(ggplot2) 

rcdata<-read.csv("C:/train_data.csv",header=TRUE)
rcdata
rcdata<-rcdata[,-c(1)]
rcdata[rcdata$user==1,]
g<-acast(rcdata, user ~ movie)
class(g)
R<-as.matrix(g)
total <- as(R, "realRatingMatrix")
total

train<-sample(total,6000)
train

#normalize the rating matrix
hist(getRatings(train), breaks=5)
#rating distribution after normalization
hist(getRatings(normalize(train, method="Z-score")), breaks=5)

#create a recommender
rec=Recommender(train[1:5400,1:3500],method="UBCF", param=list(normalize = "Z-score",method="Cosine",nn=5, minRating=1))
print(rec)

names(getModel(rec))
getModel(rec)$nn

# create predictions
recom <- predict(rec, train[5401:6000,1:3500], type="ratings")
recom

as(recom, "list")
as(recom, "matrix")[1:10,1:10]

#  MAKE SOME EVALUATION PREDICTIONS
scheme <- evaluationScheme(train, method="cross-validation", given=2, goodRating=5, k=10)

r1 <- Recommender(getData(scheme, "train"), method="UBCF",
                  param=list(normalize = "Z-score",method="Cosine",nn=5, minRating=3))
r1

#compute predicted ratings for the known part of the test data (15 items for each user)
p1 <- predict(r1, getData(scheme, "known"), type="ratings")
p1

as(p1, "list")

#calculate error between the prediction and the unknown part of the test data
error <- rbind(
  calcPredictionAccuracy(p2, getData(scheme, "unknown"))
  
)
error

##  Evaluation of a top-N recommender algorithm

#For this example we create a 10-fold cross validation scheme with the the Given-2 protocol,
#i.e., for the test users all but two randomly selected items are withheld for evaluation.
scheme <- evaluationScheme(train[1:1000,1:2400], method="cross-validation", given=2, goodRating=5, k=10)
scheme

results <- evaluate(scheme, method="UBCF", n=c(1,3,5,10,15,20))
results

#get the 1st confusion matrix
getConfusionMatrix(results)[[1]]

#get the avg of all the runs
avg(results)

# plot true positive rate vs false positive rate
plot(results, annotate=TRUE)

#create precision recall plot
plot(results, "prec/rec", annotate=TRUE)


####    Comparing recommender algorithms
#scheme <- evaluationScheme(train[1:6000,1:3500], method="cross-validation", given=2, goodRating=5, k=4)

scheme <- evaluationScheme(train[1:6000,1:3500], method="split", train = .9, k=10, given=2, goodRating=5)
scheme

algorithms <- list(
  "item-based"=list(name="UBCF", param=list(method="Cosine",nn=50, minRating=5)),
  "user-based CF" = list(name="IBCF", param=list(method="Cosine",k=50, minRating=5))
)

results <- evaluate(scheme, algorithms, n=c(1, 3, 5, 10, 15, 20))
results  
names(results)  
results[["user-based CF"]]

#plot the performance of the three algos
plot(results, annotate=TRUE, legend="topleft")  
plot(results, "prec/rec", annotate=4)  


