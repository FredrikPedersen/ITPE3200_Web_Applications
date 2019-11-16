import React from "react";
import UserQuestion from "./UserQuestion/UserQuestion";

const userQuestions = (props) => {
    return props.questions.map(uq => {
        return (
            <UserQuestion
            key={uq.id}
            id={uq.id}
            username={uq.username}
            email={uq.email}
            question={uq.question}
            />
        )
    })
    
};

export default userQuestions;