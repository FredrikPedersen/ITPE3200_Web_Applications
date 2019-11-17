import React from "react";
import Category from "./Category/Category";

const categories = (props) => {
    return props.categories.map(category => {
        let backgroundColor;
        switch (category.id) {
            case 1:
                backgroundColor = "GreenBackground";
                break;
            case 2:
                backgroundColor = "RedBackground";
                break;
            case 3:
                backgroundColor = "YellowBackground";
                break;
            case 4:
                backgroundColor = "BlueBackground";
                break;
            default:
                backgroundColor = "GreenBackground";
                break;
        }
        
        return (
            <Category
                key={category.id}
                title={category.categoryName}
                backgroundColor={backgroundColor}
                clickHandler={() =>props.clickHandler(category.categoryName)}
            />
        )
    })
};


export default categories;