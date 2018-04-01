import React, { Component } from "react";
import ContactForm from "./ContactForm";
import ContactItem from "./ContactItem";
let CONTACT_TEMPLATE = { name: "", email: "", description: "", errors: null };

class ContactsView  extends Component{
    
    constructor(props) {
        super(props);

        this.state = {
            contacts: [
                { key: 1, name: " Martin Fowler", email: "martin@fowler.com", description: "Old friend" },
            ],
            newContact: CONTACT_TEMPLATE
        }
    }
 
    static PropTypes ={
    contacts: React.PropTypes.array.isRequired,
    newContact: React.PropTypes.object.isRequired,
    onNewContactChange: React.PropTypes.func.isRequired,
    onNewContactSubmit: React.PropTypes.func.isRequired,
  }

    render() {
        var conts = this.state.contacts;
        return (
            <div className="ContactView">
                <h1 className='ContactView-title'> My React Contacts</h1>
                <ul className='ContactView-list'>
                    {conts && Object.keys(conts).map((k, index) => (
                        <ContactItem contact={conts[k]}
                        />
                    ))}
                </ul>
                <ContactForm value={this.state.newContact}
                    onChange={this.state.onNewContactChange}
                    onSubmit={this.state.onNewContactSubmit} />
            </div>
        )
    }
      
   
}
export default ContactsView;