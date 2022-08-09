import React, { Component } from 'react';

export class List extends Component {
    static displayName = List.name;

    constructor(props) {
        super(props);
        this.state = { searchResult: [], loading: true };
    }

    componentDidMount() {
        this.populateMovieData();
    }

    static renderMoviesTable(searchResult) {
        return (
            <div>
                <label>Showing {searchResult.hits.length} out of {searchResult.totalHits}</label>
                <label>Genres</label>
                <ul>
                    {searchResult.aggregations.genres.map(genre => <li key={genre.key}>{genre.key} ({genre.value})</li>)}
                </ul>
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>Title</th>
                            <th>Published</th>
                            <th>Description</th>
                            <th>Actors</th>
                        </tr>
                    </thead>
                    <tbody>
                        {searchResult.hits.map(movie =>
                            <tr key={movie.id.value}>
                                <td>{movie.title}</td>
                                <td>{movie.published}</td>
                                <td>{movie.description}</td>
                                <td>{movie.actors.join(', ')}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : List.renderMoviesTable(this.state.searchResult);

        return (
            <div>
                <h1 id="tabelLabel" >Movies</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateMovieData() {
        const response = await fetch('search');
        const data = await response.json();
        this.setState({ searchResult: data, loading: false });
    }
}
