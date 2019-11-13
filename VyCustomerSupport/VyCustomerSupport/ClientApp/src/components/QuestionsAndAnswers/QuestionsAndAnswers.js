import React, {PureComponent} from "react";
import QuestionAndAnswer from "../QuestionAndAnswer/QuestionAndAnswer";

class QuestionsAndAnswers extends PureComponent {
    render() {
        return this.props.questionsAndAnswers.map(qaa => {
            console.log(qaa);
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
    }
}

export default QuestionsAndAnswers;