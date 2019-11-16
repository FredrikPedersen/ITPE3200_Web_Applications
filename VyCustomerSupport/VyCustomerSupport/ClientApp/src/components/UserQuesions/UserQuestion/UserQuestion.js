import React from "react";
import "./UserQuestion.css";

const userQuestion = (props) => (
    <div className="UserQuestionBox">
        <p className="UserQuestion">"{props.question}"</p>
        <p className="SentBy">Fra {props.username}, {props.email}</p>
    </div>
);

export default userQuestion;