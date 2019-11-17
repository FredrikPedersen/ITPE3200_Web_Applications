import React, {Component} from 'react';
import "../../Styles.css";

import LoadingSpinner from "../../components/UI/LoadingSpinner/LoadingSpinner";
import Header from "../../components/UI/Header/Header";
import QuestionsAndAnswers from "../../components/QuestionsAndAnswers/QuestionsAndAnswers";
import Categories from "../../components/Categories/Categories";

const FAQ_INFO_TEXT = "Hva lurer du på? Her finner du svar på spørsmål som vi har besvart";
const TITLE = "Spørsmål og Svar";

export class FAQ extends Component {
    static displayName = FAQ.name;
    
    constructor(props) {
        super(props);

        this.state = {
            categories: [],
            qas: [],
            categorySelected: false,
            loading: true,
            error: false
        };

        fetch("api/index/categories")
            .then(response => response.json())
            .then(categories => {
                this.setState({categories: categories, loading: false});
            })
            .catch(error => {
                this.setState({error: true});
            });
    }
    
    categoryClickedHandler = (categoryTitle) => {
        this.setState({categorySelected: true});
        
        fetch("api/index/qaswithcategory?category=" + encodeURIComponent(categoryTitle))
            .then(response => response.json())
            .then(qas => {
                this.setState({qas: qas})
            })
            .catch(error => {
                this.setState({error: true});
            })
    };
    
    generateCategories() {
        return (
            <Categories
                categories={this.state.categories}
                clickHandler={this.categoryClickedHandler}/>
        )
    }

    generateQandA() {
        return (
            <QuestionsAndAnswers
                questionsAndAnswers={this.state.qas}/>
        )
    }

    render() {
        let categories =
            this.state.error ? <p className="ErrorMessage">Kan ikke laste inn kategorier. Vennligst kontroller Internetttilgangen </p> :
                this.state.loading ? <LoadingSpinner/> :
                    this.generateCategories();
                
        
        let qas =
            this.state.error ? <p className="ErrorMessage">Kan ikke laste inn spørsmål og svar. Vennligst kontroller Internetttilgangen </p> :
                this.state.loading ? <LoadingSpinner/> :
                    this.state.categorySelected ? this.generateQandA() :
                        null;
                        


        return (
            <div className="ContentArea">
                <Header
                    infoText={FAQ_INFO_TEXT}
                >{TITLE}</Header>
                {categories}
                <div style={{width: "100%", paddingTop: "3em"}}></div> {/*Empty div to create space */}
                {qas}
                <div style={{width: "100%", paddingTop: "3em"}}></div> {/*Empty div to create space */}
            </div>
        );
    }
}
