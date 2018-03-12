

//let url = 'https://news.google.com/news/feeds?pz=1&cf=all&ned=us&hl=en&q=nodejs&output=rss';

//parse(url).then((feed) => {
//    console.log(feed);
//}).catch((err) => {
//    console.log(err);
//}).finally(() => {
//    console.log('Everything done');
//});

import React, { Component } from "react";
import { Button } from "react-bootstrap";
import Reader from "feed-reader";
import PropTypes from "prop-types";
import FeedItem from "./FeedItem.js";
const parser = Reader.parse;

class Feed extends PureComponent {
    constructor(props) {
        super(props);
        this.state = { items: null };
        fetchFeed(this.props.url);
    }

    static PropTypes = {
        layout: PropTypes.object,
        url: PropTypes.string.isRequired,
        items: PropTypes.object
     };

    fetchFeed = (url) => {
        parser(url).then((feed) => {
            console.log(feed);
            setState(items=feed);
        }).catch((err) => {
            console.log(err);
            alert("err");
        }).finally(() => {
            console.log('Everything done');
        });
    }

    handleOnClick = event => {
        this.state.url = this.props.url;
        //this.props.history.push({ pathname: "/chargepoint" });
    };

    fetchFeed=()=>
    render() {
        //var url = this.props.url;
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
