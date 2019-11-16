﻿﻿import React, {Component} from "react";
import "../../Styles.css";
import Header from "../../components/UI/Header/Header";
import InputElement from "../../components/UI/InputElement/InputElement";
import Spinner from "../../components/UI/LoadingSpinner/LoadingSpinner";

const SEND_INFO_TEXT = "Noe du lurer på som ikke er besvart fra før? Send det inn her! Vi vil svare på så mange vi kan når vi har kapasitet.";
const TITLE = "Send inn Spørsmål";

export class SendQuestion extends Component {
    state = {
        formIsValid: false,
        loading: false,
        
        questionForm: {
            Brukernavn: {
                elementType: "input",
                elementConfig: {
                    type: "text",
                    placeholder: "Navn (vil bli vist til andre brukere)"
                },
                value: "",
                validation: {
                    required: true
                },
                valid: false,
                touched: false
            },
            Mailadresse: {
                elementType: "input",
                elementConfig: {
                    type: "email",
                    placeholder: "Mailadresse, eks mail@mail.com"
                },
                value: "",
                validation: {
                    required: true,
                    regex: /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
                },
                valid: false,
                touched: false
            },
            Spørsmål: {
                elementType: "textarea",
                elementConfig: {
                    type: "text",
                    placeholder: "Skriv ditt spørsmål her"
                },
                value: "",
                validation: {
                    required: true
                },
                valid: false,
                touched: false
            },
        }
    };
    
    clearForms = () => {
        const updatedForm = {
            ...this.state.questionForm
        };
        
        for (let key in updatedForm) {
            updatedForm[key].value = "";
        }
        
        this.setState({questionForm: updatedForm, formIsValid: false});
    };
    
    checkElementValidity(value, rules) {
        let isValid = true;
        
        if (rules.required) {
            isValid = value.trim() !== "" && isValid;
        }
        
        if (rules.regex) {
            isValid = rules.regex.test(value.trim())
        }
        
        return isValid;
    }
    
    checkFormValidity(updatedForm) {
        let formIsValid = true;
        
        for (let inputIdentifier in updatedForm) {
            formIsValid = updatedForm[inputIdentifier].valid && formIsValid;
        }
        
        return formIsValid;
    }

    inputChangedHandler = (event, inputIdentifier) => {
        const updatedForm = {
            ...this.state.questionForm
        };

        const updatedFormElement = {
            ...updatedForm[inputIdentifier]
        };

        updatedFormElement.value = event.target.value;
        updatedFormElement.valid = this.checkElementValidity(updatedFormElement.value, updatedFormElement.validation);
        updatedFormElement.touched = true;

        updatedForm[inputIdentifier] = updatedFormElement;

        this.setState({questionForm: updatedForm, formIsValid: this.checkFormValidity(updatedForm)});
    };
    
    formSubmissionHandler = (event) => {
        event.preventDefault();
        this.setState({loading: true});
        const formData = {};
        
        for (let formElementIdentifier in this.state.questionForm) {
            formData[formElementIdentifier] = this.state.questionForm[formElementIdentifier].value;
        }
        
        const data = {Username: formData.Brukernavn, Email: formData.Mailadresse, Question: formData.Spørsmål, UpVotes: 0, DownVotes: 0};

        fetch("api/index/sendquestion/", {
            method: "Post",
            body: JSON.stringify(data),
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(response =>  {
                response.json();
                this.setState({loading: false});
            })
            .catch(error => this.setState({error: true}));
    };
    
    createForm() {
        const formElements = [];
        
        for (let key in this.state.questionForm) {
            formElements.push({
                id: key,
                config: this.state.questionForm[key]
            });
        }
        
        //TODO REMEMBER TO SET AN ERROR MESSAGE!
        let form;
        this.state.loading ? form = <Spinner /> : form = (
            <form onSubmit={this.formSubmissionHandler}>
                {formElements.map(formElement => (
                    <InputElement
                        key={formElement.id}
                        label={formElement.config.validation.required ? formElement.id + "*" : formElement.id}
                        elementType={formElement.config.elementType}
                        elementConfig={formElement.config.elementConfig}
                        value={formElement.config.value}
                        invalid={!formElement.config.valid}
                        shouldValidate={formElement.config.validation}
                        touched={formElement.config.touched}
                        changed={(event) => this.inputChangedHandler(event, formElement.id)}/>
                ))}
            </form>
        );
        
        return form;
    }
    
    render() {
        let form = this.createForm();
        
        return(
            <div className="ContentArea">
                <Header
                infoText={SEND_INFO_TEXT}
                >{TITLE}</Header>
                {form}
                <p className="Info">* Obligatorisk felt</p>
                <button className="FormSubmitButton" onClick={this.formSubmissionHandler} disabled={!this.state.formIsValid}>Send Spørsmål</button>
                <button className="ClearButton" onClick={this.clearForms}>Tøm Felter</button>
            </div>
        );
    }
}