import React from "react"
import "./Category.css";

const category = (props) => {
    const styleClasses = "CategoryBox " + props.backgroundColor;
    
    return (
        <div className={styleClasses} onClick={props.clickHandler}>
            <p>{props.title}</p>
        </div>
    );
};

export default category;
