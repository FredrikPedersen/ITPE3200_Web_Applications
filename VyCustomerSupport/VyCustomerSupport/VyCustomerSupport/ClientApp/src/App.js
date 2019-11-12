import React, { Component } from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './containers/Layout/Layout';
import { FAQ } from './containers/FAQ/FAQ';
import { SendQuestion } from "./containers/SendQuestion/SendQuestion";
import { TestingContainer } from "./containers/TestingContainer/TestingContainer";

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route path="/send-question" component={SendQuestion} />
        <Route path="/testing" component={TestingContainer}/>
        <Route path="/faq" component={FAQ} />
        <Route path="/" exact component={FAQ}/> {/*Redirecting everything from baseURL/ to /faq*/}
      </Layout>
    );
  }
}
