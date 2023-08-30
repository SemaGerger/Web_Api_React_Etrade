import React, { Component } from 'react';
import axios from 'axios';

class CategoryList extends Component {
    constructor(props) {
        super(props);
        this.state = {
            categories: []
        };
    }

    componentDidMount() {
        this.fetchCategories();
    }

    fetchCategories() {
        axios.get('https://localhost:7203/api/Category/List')
            .then(response => {
                this.setState({ categories: response.data });
            })
            .catch(error => {
                console.error('API request error:', error);
            });
    }

    render() {
        const { categories } = this.state;

        return (
            <div>
                <h2>Category List</h2>
               
                    {categories.map((category, index) => (
                        <p key={category.id}>
                        {index + 1}.
                        {category.description}
                    </p>
                    ))}
                
            </div>
        );
    }
}

export default CategoryList;
