import React, { Component } from "react";
import { Button } from "react-bootstrap";
import Parser from "feedparser-promised";
import PropTypes from "prop-types";
import FeedItem from "./FeedItem";




class Feed extends Component {
    constructor(props) {
        super(props);
        this.state = { items: null };
        this.fetchFeed(this.props.url);
    }
 
    static PropTypes = {
        layout: PropTypes.object,
        url: PropTypes.string.isRequired,
        items: PropTypes.object
     };

    fetchFeed = (url) => {
        const httpOptions = {
            uri: url,
            timeout: 5000,
            gzip: false,
            //headers: {
            //    'Access-Control-Allow-Headers':'Content-Type',
            //'Access-Control-Allow-Origin': 'http://localhost/*',
            //    'Access-Control-Allow-Methods': 'GET,POST,OPTIONS,HEAD',
                //'Content-Type': 'application/x-rss+xml'
            //}


        };
        
       Parser.parse(httpOptions).then((feed) => {
            console.log(feed);
            setState(items=feed);
        }).catch((err) => {
            console.log(err);
            alert("Parsing error");
        }).finally(() => {
            console.log('Everything done');
        });
    }

    handleOnClick = event => {
        this.state.url = this.props.url;
        //this.props.history.push({ pathname: "/chargepoint" });
    };

 
    render() {
   
        var feeds = this.props.items;
       console.log("feeds " + this.props.items);
        return (
            <div class="container">
                <div class="row dark note">
                    <div class="col-sm-6 other">
                        <h4>International news</h4>
                    </div>
                    <div class="col-sm-6 other2">
                        <div>
                           <Button  type="submit"
                                    className="btn-inverse gdark"
                                    onClick={this.handleOnClick}
                                >
                                    <h2 class="animated wobble">Get RSS</h2>
                                </Button>
                            {this.props.items &&
                                Object.keys(this.props.items).map((k, index) => (
                                    <FeedItem
                                        title={items[k].title}
                                        link={connectors[k].link}
                                        date={connectors[k].publishedDate}
                                   />
                                ))}
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

export default Feed;
