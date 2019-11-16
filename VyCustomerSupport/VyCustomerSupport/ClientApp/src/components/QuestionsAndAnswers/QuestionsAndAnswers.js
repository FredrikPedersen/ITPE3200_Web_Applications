import React from "react";
import QuestionAndAnswer from "./QuestionAndAnswer/QuestionAndAnswer";

const questionsAndAnswers = (props) => {
    return props.questionsAndAnswers.map(qaa => {
        return (
            <QuestionAndAnswer
                key={qaa.id}
                id={qaa.id}
                question={qaa.question}
                answer={qaa.answer}
                upVotes={qaa.upVotes}
                downVotes={qaa.downVotes}/>
        )
    })
};

export default questionsAndAnswers;