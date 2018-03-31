import React, { Component } from 'react';
import ContactsView from './contacts/ContactsView';
import Feed from './rss/Feed';
var CONTACT_TEMPLATE = { name: "", email: "", description: "", errors: null };

let url1 = "http://www.fontanka.ru/fontanka.rss"
let url2 = "http://feeds.bbci.co.uk/news/rss.xml?edition=int"
let url3 = "https://www.rt.com/rss/"
const isProduction = process.env.NODE_ENV === "production";
const CORS_PROXY =isProduction ? "": "https://cors-anywhere.herokuapp.com/"

export { isProduction };

export default class App extends Component {
    constructor(props) {
        super(props);
        this.state = {contacts: [
                { key: 1, name: " Martin Fowler", email: "martin@fowler.com", description: "Old friend" },
            ],
            newContact: CONTACT_TEMPLATE}
    }
    //componentDidMount() { }

    render() {
        return (

            <div className="container">
                <div className="row dark note">
                    <div className="col-sm-4">
                        <h4>React contacts form</h4>
                    </div>
                    <div className="col-sm-8">
                        <h4>International news - a React RSS feeds component with CORS</h4>
                             <div className="row">
                            <div className="col-sm-4">
                            <Feed url={url1} />
                        </div>
                            <div className="col-sm-4">
                            <Feed url={url2} />
                        </div>
                            <div className="col-sm-4">
                            <Feed url={url3} />
                            </div>

                        </div>
                        <div className="clearfix visible-xs"/>
                    </div>
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

