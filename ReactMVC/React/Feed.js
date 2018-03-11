

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
        this.state = this.props;
    }

    static PropTypes = {
        match: PropTypes.object.isRequired,
        layout: PropTypes.object,
        url: PropTypes.string,
     };

    handleOnClick = event => {
        this.state.url = this.props.url;
        //this.props.history.push({ pathname: "/chargepoint" });
    };
    render() {
        var url = this.props.url;
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
                            {this.props.location.pathname == "/nearby" && (
                                <Button
                                    type="submit"
                                    className="btn-inverse gdark"
                                    onClick={this.handleOnClick}
                                >
                                    <h2 class="animated wobble">Get RSS</h2>
                                </Button>
                            )}

                            {this.props.feeds &&
                                Object.keys(this.props.feeds).map((k, index) => (
                                    <FeedItem
                                        type={feeds[k].connectorPowerType}
                                        status={connectors[k].connectorStatus}
                                        shape={connectors[k].connectorShape}
                                        number={connectors[k].connectorId}
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
