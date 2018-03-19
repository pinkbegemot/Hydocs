import React, { Component } from 'react';
//import ContactsView from './ContactsView';
//import Feed from './Feed';
var CONTACT_TEMPLATE = { name: "", email: "", description: "", errors: null };
//var url = "https://www.rt.com/rss/";
var url = "http://www.fontanka.ru/fontanka.rss"

export default class App extends Component {
    constructor(props) {
        super(props);
        this.state = {contacts: [
                { key: 1, name: " Martin Fowler", email: "martin@fowler.com", description: "Old friend" },
            ],
            newContact: CONTACT_TEMPLATE}
    }
    componentDidMount() {
        //this.authenticate();
    }
    //authenticate(e) {
    //    if (e) e.preventDefault();
    //    this.store.appState.authenticate();
    //}
    render() {
        return (

            <div id="appContainer" className=".container-fluid">
                <header id="header" className="container">
                </header>
                <div className=".container-fluid">
        
                </div>
          
            </div>

        );
    }
/*
 * Actions
 */


updateNewContact = (contact) => {
    setState({ newContact: contact });
}


submitNewContact = () => {
    var contact = Object.assign({}, state.newContact, { key: state.contacts.length + 1, errors: {} });

    if (!contact.name) {
        contact.errors.name = ["Please enter your new contact's name"]
    }
    if (!/.+@.+\..+/.test(contact.email)) {
        contact.errors.email = ["Please enter your new contact's email"]
    }

    setState(
        Object.keys(contact.errors).length === 0
            ? {
                newContact: Object.assign({}, CONTACT_TEMPLATE),
                contacts: state.contacts.slice(0).concat(contact),

            }
            : { newContact: contact }
    )
    var div = $(".ContactView-title");
    $(div).fadeOut();

    $(div).fadeIn(2500, "linear", null);

}
Display=(el)=>{

    el.style.display = "block" ? el.style.display = "none" : el.style.display = "block";

    return el;

}
    
}

