import React, { Component } from 'react';
//import GreyLayout from '../../layouts/GreyLayout.jsx';
//import { Button } from 'react-bootstrap';


class FeedItem extends Component {

    constructor(props) {
        super(props);
        this.state = { title: "", link:"", date:"" };
    }

    render() {
        let title = this.props.title == 'Undefined' ? "" : this.props.title
        let link = this.props.link == 'Undefined' ? "" : this.props.link
        let date = this.props.date == 'Undefined' ? "n/a" : this.props.date

        return (
            title.length > 0 ?
                 <div className="row">
                            <p>{title} </p>
                            <p>{date}<a href={link} class="magenta" target="_blank"><b> &nbsp>>>>></b> </a> </p>
                            <div class="v-space-20" />
                    </div>
                : null
        )
    }
}
export default FeedItem;


