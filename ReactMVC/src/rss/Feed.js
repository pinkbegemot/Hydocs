﻿import React, { Component } from "react";
import { Button } from "react-bootstrap";
import PropTypes from "prop-types";
import FeedItem from "./FeedItem"
//var client = require('./services/axios/client');
let Parser = require('rss-parser');
let parser = new Parser();

class Feed extends Component {
    constructor(props) {
        super(props);
        this.state = { rssItems: null };
        this.fetchFeed(this.props.url);
    }

    static PropTypes = {
        layout: PropTypes.object,
        url: PropTypes.string.isRequired,
        rssItems: PropTypes.object
    };

    fetchFeed = (url) => {
        console.log("before fetching");
        parser.parseURL(url).then((feed) => {
            console.log(feed.items);
            this.setState({ rssItems: feed.items });
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

        var feeds = this.state.rssItems;
        console.log("feeds " + this.props.items);
        return (
            <div>
               
                        <h4>{this.props.url}</h4>
             
                    
                          {feeds&&Object.keys(feeds).map((k, index) => (
                                    <FeedItem
                                        title={feeds[k].title}
                                        link={feeds[k].link}
                                        date={feeds[k].pubDate}
                                    />
                                ))}
            </div>
        );
    }
}

export default Feed;
