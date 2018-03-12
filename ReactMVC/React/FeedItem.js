// @flow weak

import React, {PureComponent} from 'react';
//import GreyLayout from '../../layouts/GreyLayout.jsx';
//import { Button } from 'react-bootstrap';
//import 'react-table/react-table.css';

class FeedItem extends PureComponent {

    constructor(props) {
        super(props);
        this.state = { title: "", link:"", publishedDate:"" };
    }

    //    <div class="container">
    //<div class="blank"></div>
    //<div class="row">
    //    <div id="react-app" class="col-sm-4"></div>
    //    <div id="rss-feeds" class="col-sm-4">@Html.Action("_IntRss")</div>
    //    <div class="col-sm-4">
    //        <h3>Even more news</h3>

    //        @foreach (var item in ViewBag.RssFeed)
    //        {
    //                    <div class="feed">
    //                        <p><b>@item.Title</b></p>
    //                        <p>@Convert.ToDateTime(item.PubDate) <a href="link" class="magenta" target="_blank">><b>>></b> </a> </p>
    //                    </div>
    //        }
    //    </div>
    //    <div class="clearfix"></div>

    //</div>
//</div>

    render() {
        let title = this.props.title == 'Undefined' ? "" : this.props.title
        let link = this.props.link == 'Undefined' ? "" : this.props.link
        let date = this.props.publishedDate == 'Undefined' ? "n/a" : this.props.publishedDate

        return (
            title.length > 0 ?
                 <div className="row">
                        <div class="col-sm-12">
                            <p>{title} </p>
                            <p>{date}<a href={link} class="magenta" target="_blank"><b>>></b> </a> </p>
                            <div class="v-space-20" />
                        </div>
                   </div>
                : null
        )
    }
}
export default FeedItem;


