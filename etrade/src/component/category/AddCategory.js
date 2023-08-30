import React, { Component } from 'react';
import axios from 'axios';
import CategoryList from './CategoryList';

class AddCategory extends Component {
    constructor(props) {
        super(props);
        this.state = {
            categoryName: '',
            description: ''
        };
    }

    handleInputChange = event => {
        const { name, value } = event.target;
        this.setState({ [name]: value });
    }

    handleSubmit = event => {
        event.preventDefault();
        const { categoryName, description } = this.state;

        const newCategory = {
            categoryName,
            description
        };

        axios.post('https://localhost:7203/api/Category/Create', newCategory)
            .then(response => {
                console.log('Category added:', response.data);

                // Kategori başarıyla eklendikten sonra yapılacak işlemler
                alert('Category added successfully!');
                this.setState({ categoryName: '', description: '' });
            })
            .catch(error => {
                console.error('API request error:', error);
            });
    }

    render() {
        const { categoryName, description } = this.state;

        return (
            <div>
                <h2>Add Category</h2>
                <form onSubmit={this.handleSubmit}>
                    <div className="form-group">
                        <label>Category Name:</label>
                        <input
                            type="text"
                            name="categoryName"
                            value={categoryName}
                            onChange={this.handleInputChange}
                            className="form-control"
                            required
                        />
                    </div>
                    <div className="form-group">
                        <label>Description:</label>
                        <input
                            type="text"
                            name="description"
                            value={description}
                            onChange={this.handleInputChange}
                            className="form-control"
                        />
                    </div>
                    <button type="submit" className="btn btn-primary">Add Category</button>
                </form>
                <CategoryList />
            </div>
        );
    }
}

export default AddCategory;
