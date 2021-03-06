﻿using BookShelf.Shared.Model;
using Microsoft.AspNetCore.Blazor;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookShelf.UI.Services
{
    public class BookService
    {
        private readonly HttpClient _httpClient;

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _httpClient.GetJsonAsync<List<Book>>("https://uhguay2qye.execute-api.eu-west-2.amazonaws.com/Books/books");
        }

        public async Task PostBook(Book book)
        {
            await _httpClient.SendJsonAsync(HttpMethod.Post, "https://uhguay2qye.execute-api.eu-west-2.amazonaws.com/Books/books", book);
        }

        public async Task DeleteBook(string bookId)
        {
            await _httpClient.DeleteAsync("https://uhguay2qye.execute-api.eu-west-2.amazonaws.com/Books/books?bookId=" + bookId);
        }

        public async Task<bool> Reset()
        {
            return await _httpClient.GetJsonAsync<bool>("https://uhguay2qye.execute-api.eu-west-2.amazonaws.com/Books/reset");
        }
    }
}
