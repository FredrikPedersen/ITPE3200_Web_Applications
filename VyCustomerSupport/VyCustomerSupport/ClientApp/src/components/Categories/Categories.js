import React from "react";
import Category from "./Category/Category";

const categories = (props) => {
    return props.categories.map(category => {
        return (
            <Category
                key={category.id}
                title={category.categoryName}
                clickHandler={() =>props.clickHandler(category.categoryName)}
            />
        )
    })
};


export default categories;