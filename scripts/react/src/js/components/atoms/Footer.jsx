import React from "react";

export default class Footer extends React.Component {
    render() {
        const { title } = this.props;
        return (
          <footer>
            <div className="row">
              <div className="col-lg-12">
                  <p>Copyright &copy; { title }</p>
              </div>
            </div>
          </footer>
        );
  }
}