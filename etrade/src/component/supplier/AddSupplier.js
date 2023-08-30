import React, { Component  } from 'react';
import axios from 'axios';
import { ToastContainer, toast } from 'react-toastify';
import SupplierList from './SupplierList';

class AddSupplier extends Component {

   
    constructor(props) {
        super(props);
        this.state = {
            description: '',
            city: '',
            no: 0,
            taxNo: 0
        };
    }
   
    handleInputChange = event => {
        const { name, value } = event.target;
        this.setState({ [name]: value });
    }
    
   
    handleSubmit = event => {
        event.preventDefault();
        const {  city, no, taxNo, description } = this.state;

        const newSupplier = {
            description,
            city,
            no,
            taxNo
        };

        axios.post('https://localhost:7203/api/Supplier/Create', newSupplier)
            .then(response => {
                console.log('Supplier added:', response.data);
                toast.success('İşleminiz gerçekleşti. "İleri" tuşuna basarak bir sonraki adıma geçin');
               
                this.setState({
                    description: '',
                    city: '',
                    no: 0,
                    taxNo: 0
                });
            })
            .catch(error => {
                console.error('API request error:', error);
            });


    }
 
    render() {
        const {  city, no, taxNo, description } = this.state;

        return (
            <div > 
                <h2>Add Supplier</h2>
                <form onSubmit={this.handleSubmit}>
                <div className="form-group">
                        <label>Description</label>
                        <input
                            type="text"
                            name="description"
                            value={description}
                            onChange={this.handleInputChange}
                            className="form-control"
                            required
                        />
                    </div>
                    <div className="form-group">
                        <label>City:</label>
                        <input
                            type="text"
                            name="city"
                            value={city}
                            onChange={this.handleInputChange}
                            className="form-control"
                            required
                        />
                    </div>
                    <div className="form-group">
                        <label>No:</label>
                        <input
                            type="number"
                            name="no"
                            value={no}
                            onChange={this.handleInputChange}
                            className="form-control"
                            required
                        />
                    </div>
                    <div className="form-group">
                        <label>Tax No:</label>
                        <input
                            type="number"
                            name="taxNo"
                            value={taxNo}
                            onChange={this.handleInputChange}
                            className="form-control"
                            required
                        />
                    </div>
                   
                    <button type="submit" className="btn btn-primary">Add Supplier</button>
                    <ToastContainer />

                   
                </form>
                <SupplierList />
            </div>
        );
    }
}

export default AddSupplier;
