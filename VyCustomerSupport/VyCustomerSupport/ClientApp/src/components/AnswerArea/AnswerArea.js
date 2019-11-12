import React from "react";

const answerArea = (props) => {
  const styleClass = classNames("AnswerArea", {
      "AnswerArea--hidden": !props.isOpen
  });
  
  return(
      <dd>
          <p
              className={styleClass} id={props.id}>
              {props.children}</p>
      </dd>
  )
      
  
    
    
};

export default answerArea;