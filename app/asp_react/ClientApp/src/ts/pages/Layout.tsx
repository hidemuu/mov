import * as React from "react";
import { RouteComponentProps, withRouter } from "react-router-dom";
import Header from "../components/atoms/Header";
import Footer from "../components/atoms/Footer";

interface ILayout extends RouteComponentProps {
    children: object,
}

export class Layout extends React.Component<ILayout, {}> {

    render(): JSX.Element {
        const containerStyle = {
            marginTop: "0px"
        };
        console.log("layout");
        console.log(this.props.children);
        return (
            <div>
                <div className="container" style={containerStyle}>
                    {/* <Header /> */}
                    <div className="row">
                        <div className="col-lg-12">
                            {this.props.children}
                        </div>
                    </div>
                    <Footer title="Covid Reader" />
                </div>
            </div>

        );
    }
}

export default withRouter(Layout);