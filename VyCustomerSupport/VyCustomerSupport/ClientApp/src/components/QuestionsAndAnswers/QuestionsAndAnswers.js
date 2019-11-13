import React, {PureComponent} from "react";
import QuestionAndAnswer from "../QuestionAndAnswer/QuestionAndAnswer";

class QuestionsAndAnswers extends PureComponent {
    render() {
        return this.props.questionsAndAnswers.map(qaa => {
            return (
                <QuestionAndAnswer
                    key={qaa.id}
                    question={qaa.question}
                    answer={qaa.answer}/>
            )
        })
    }
}

export default QuestionsAndAnswers;