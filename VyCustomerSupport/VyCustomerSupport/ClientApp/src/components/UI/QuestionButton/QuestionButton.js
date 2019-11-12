import React from "react";
import "./QuestionButton.css";

const questionButton = (props) => (
    <dt>
        <button 
            className="QuestionButton"
            aria-expanded={props.isOpen}
            aria-controls={props.answerId}
            onClick={props.onToggle} 
        >{props.children} </button>
    </dt>
);

export default questionButton;