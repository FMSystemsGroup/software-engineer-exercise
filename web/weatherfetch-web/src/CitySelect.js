import React, {Component} from "react";
import {callGet, handleInputChange} from "./Helpers";

class CitySelect extends Component {
    constructor(props){
        super(props);
        this.state = {
            cityList: [],
            selectedCityId: -1,
            summary: "",
            temperature: "",
            uvIndex: ""
        };

        this.clearInfo = this.clearInfo.bind(this);
        this.getWeatherForSelectedCity = this.getWeatherForSelectedCity.bind(this);
        this.handleSelectChange = this.handleSelectChange.bind(this);
    }

    componentDidMount(){
        let ctrl = this;

        callGet('city').then(response =>{
            if(response.status !== 200){
                alert('There was a problem fetching the city list.');
                return;
            }

            response.json().then(cities =>{
                console.log(cities);
                ctrl.setState({
                    cityList: cities
                });
            });
        })
    }

    handleSelectChange(event){
        let ctrl = this;
        //update the state and then fetch the weather
        handleInputChange(event, this, () =>{
            var cityInt = parseInt(ctrl.state.selectedCityId);
            if(isNaN(cityInt)){
                alert('There was an error selecting a city.');
                return;
            }

            if(cityInt > -1){
                ctrl.clearInfo(ctrl.getWeatherForSelectedCity);
            }
        });
    }

    clearInfo(postClearAction){
        this.setState({
            summary: "",
            temperature: "",
            uvIndex: ""
        }, postClearAction)
    }

    getWeatherForSelectedCity(){
        let ctrl = this;
        callGet('Weather/ForCity/' + this.state.selectedCityId)
        .then(response => {
            if(response.status !== 200){
                alert('There was an error fetching the weather for the selected city')
                return;
            }

            response.json().then(weather => {
                if(weather.currently){
                    ctrl.setState({
                        summary: weather.currently.summary ? weather.currently.summary : 'No summary available',
                        temperature: weather.currently.temperature,
                        uvIndex: weather.currently.uvIndex
                    })
                }
            });
        })
    }

    render() {
        return(
            <div>
                <select onChange={this.handleSelectChange} name="selectedCityId" value={this.state.selectedCityId}>
                    <option value="-1">Choose a city</option>
                    {this.state.cityList.map((city, index) => (
                        <option key={index} value={city.id}>{city.name}, {city.state}</option>
                    ))}
                </select>
                {this.state.selectedCityId > -1? //only show data when a valid city is selected
                <div>
                    <p>Summary: {this.state.summary}</p>
                    <p>Temperature: {this.state.temperature}</p>
                    <p>UV Index: {this.state.uvIndex}</p>
                </div>
                :null}
            </div>
        )
  }
}

export default CitySelect;