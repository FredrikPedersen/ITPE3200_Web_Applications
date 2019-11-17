import React from "react"
import "./Category.css";

const category = (props) => {
    return (
        <div className="CategoryBox" onClick={props.clickHandler}>
            <p>{props.title} <i className="fa fa-arrow-right"></i></p>
        </div>
    );
};

export default category;
