import React, { Component } from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './containers/Layout/Layout';
import { FAQ } from './containers/FAQ/FAQ';
import { SendQuestion } from "./containers/SendQuestion/SendQuestion";
import { UserQuestions } from "./containers/UserQuestions/UserQuestions";

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route path="/send-spørsmål" component={SendQuestion} />
        <Route path="/faq" component={FAQ} />
        <Route path="/innsendte-spørsmål" component={UserQuestions}/>
        <Route path="/" exact component={FAQ}/> {/*Redirecting everything from baseURL/ to /faq*/}
      </Layout>
    );
  }
}
