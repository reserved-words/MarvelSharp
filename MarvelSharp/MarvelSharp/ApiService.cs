using System.Collections.Generic;
using System.Threading.Tasks;
using MarvelSharp.Criteria;
using MarvelSharp.Internal.Services;
using MarvelSharp.Model;

namespace MarvelSharp.Core
{
    public class ApiService
    {
        private readonly CharacterService _characterService;
        private readonly ComicService _comicService;
        private readonly CreatorService _creatorService;
        private readonly EventService _eventService;
        private readonly SeriesService _seriesService;
        private readonly StoryService _storyService;

        /// <summary>
        ///     Initializes a new instance of the ApiService class
        /// </summary>
        /// <param name="apiPublicKey">The public API key provided by Marvel</param>
        /// <param name="apiPrivateKey">The private API key provided by Marvel</param>
        public ApiService(string apiPublicKey, string apiPrivateKey)
        {
            _characterService = ServiceLocator.GetCharacterService(apiPublicKey, apiPrivateKey);
            _comicService = ServiceLocator.GetComicService(apiPublicKey, apiPrivateKey);
            _creatorService = ServiceLocator.GetCreatorService(apiPublicKey, apiPrivateKey);
            _eventService = ServiceLocator.GetEventService(apiPublicKey, apiPrivateKey);
            _seriesService = ServiceLocator.GetSeriesService(apiPublicKey, apiPrivateKey);
            _storyService = ServiceLocator.GetStoryService(apiPublicKey, apiPrivateKey);
        }

        /// <summary>
        ///     Fetches a list of comic characters, with optional filters
        /// </summary>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <returns></returns>
        public async Task<Response<List<Character>>> GetAllCharactersAsync(int? limit = null, int? offset = null,
            CharacterCriteria criteria = null)
        {
            return await _characterService.GetAllAsync(limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches a list of comics, with optional filters
        /// </summary>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Comic>>> GetAllComicsAsync(int? limit = null, int? offset = null,
            ComicCriteria criteria = null)
        {
            return await _comicService.GetAllAsync(limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches a list of comic creators, with optional filters
        /// </summary>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Creator>>> GetAllCreatorsAsync(int? limit = null, int? offset = null,
            CreatorCriteria criteria = null)
        {
            return await _creatorService.GetAllAsync(limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches a list of events, with optional filters
        /// </summary>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Event>>> GetAllEventsAsync(int? limit = null, int? offset = null,
            EventCriteria criteria = null)
        {
            return await _eventService.GetAllAsync(limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches a list of comic series, with optional filters
        /// </summary>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Series>>> GetAllSeriesAsync(int? limit = null, int? offset = null,
            SeriesCriteria criteria = null)
        {
            return await _seriesService.GetAllAsync(limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches a list of stories, with optional filters
        /// </summary>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Story>>> GetAllStoriesAsync(int? limit = null, int? offset = null,
            StoryCriteria criteria = null)
        {
            return await _storyService.GetAllAsync(limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches details for the specified character
        /// </summary>
        /// <param name="characterId">The character ID.</param>
        /// <returns></returns>
        public async Task<Response<Character>> GetCharacterByIdAsync(int characterId)
        {
            return await _characterService.GetByIdAsync(characterId);
        }

        /// <summary>
        ///     Fetches a list of comics containing the specified character, with optional filters
        /// </summary>
        /// <param name="characterId">The character ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Comic>>> GetCharacterComicsAsync(int characterId, int? limit = null,
            int? offset = null, ComicCriteria criteria = null)
        {
            return await _comicService.GetByCharacterAsync(characterId, limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches a list of events in which the specified character appears, with optional filters
        /// </summary>
        /// <param name="characterId">The character ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Event>>> GetCharacterEventsAsync(int characterId, int? limit = null,
            int? offset = null, EventCriteria criteria = null)
        {
            return await _eventService.GetByCharacterAsync(characterId, limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches a list of comic series in which the specified character appears, with optional filters.
        /// </summary>
        /// <param name="characterId">The character ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Series>>> GetCharacterSeriesAsync(int characterId, int? limit = null,
            int? offset = null, SeriesCriteria criteria = null)
        {
            return await _seriesService.GetByCharacterAsync(characterId, limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches a list of comic stories featuring the specified character, with optional filters
        /// </summary>
        /// <param name="characterId">The character ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Story>>> GetCharacterStoriesAsync(int characterId, int? limit = null,
            int? offset = null, StoryCriteria criteria = null)
        {
            return await _storyService.GetByCharacterAsync(characterId, limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches details for the specified comic
        /// </summary>
        /// <param name="comicId">The comic ID.</param>
        /// <returns></returns>
        public async Task<Response<Comic>> GetComicByIdAsync(int comicId)
        {
            return await _comicService.GetByIdAsync(comicId);
        }

        /// <summary>
        ///     Fetches a list of characters that appear in a specific comic, with optional filters
        /// </summary>
        /// <param name="comicId">The comic ID.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <returns></returns>
        public async Task<Response<List<Character>>> GetComicCharactersAsync(int comicId, int? limit = null,
            int? offset = null, CharacterCriteria criteria = null)
        {
            return await _characterService.GetByComicAsync(comicId, limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches a list of comic creators whose work appears in the specified comic, with optional filters
        /// </summary>
        /// <param name="comicId">The comic ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Creator>>> GetComicCreatorsAsync(int comicId, int? limit = null,
            int? offset = null, CreatorCriteria criteria = null)
        {
            return await _creatorService.GetByComicAsync(comicId, limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches a list of events in which a specific comic appears, with optional filters
        /// </summary>
        /// <param name="comicId">The comic ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Event>>> GetComicEventsAsync(int comicId, int? limit = null, int? offset = null,
            EventCriteria criteria = null)
        {
            return await _eventService.GetByComicAsync(comicId, limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches a list of comic stories in a specific comic issue, with optional filters
        /// </summary>
        /// <param name="comicId">The comic ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Story>>> GetComicStoriesAsync(int comicId, int? limit = null,
            int? offset = null, StoryCriteria criteria = null)
        {
            return await _storyService.GetByComicAsync(comicId, limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches details for the specified comic creator
        /// </summary>
        /// <param name="creatorId">The creator ID.</param>
        /// <returns></returns>
        public async Task<Response<Creator>> GetCreatorByIdAsync(int creatorId)
        {
            return await _creatorService.GetByIdAsync(creatorId);
        }

        /// <summary>
        ///     Fetches a list of comics in which the work of the specified creator appears, with optional filters
        /// </summary>
        /// <param name="creatorId">The creator ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Comic>>> GetCreatorComicsAsync(int creatorId, int? limit = null,
            int? offset = null, ComicCriteria criteria = null)
        {
            return await _comicService.GetByCreatorAsync(creatorId, limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches a list of events featuring the work of a specific creator, with optional filters
        /// </summary>
        /// <param name="creatorId">The creator ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Event>>> GetCreatorEventsAsync(int creatorId, int? limit = null,
            int? offset = null, EventCriteria criteria = null)
        {
            return await _eventService.GetByCreatorAsync(creatorId, limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches a list of comic series in which the specified creator's work appears, with optional filters
        /// </summary>
        /// <param name="creatorId">The creator ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Series>>> GetCreatorSeriesAsync(int creatorId, int? limit = null,
            int? offset = null, SeriesCriteria criteria = null)
        {
            return await _seriesService.GetByCreatorAsync(creatorId, limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches a list of comic stories by the specified creator, with optional filters
        /// </summary>
        /// <param name="creatorId">The creator ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Story>>> GetCreatorStoriesAsync(int creatorId, int? limit = null,
            int? offset = null, StoryCriteria criteria = null)
        {
            return await _storyService.GetByCreatorAsync(creatorId, limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches details for the specified event
        /// </summary>
        /// <param name="eventId">The event ID.</param>
        /// <returns></returns>
        public async Task<Response<Event>> GetEventByIdAsync(int eventId)
        {
            return await _eventService.GetByIdAsync(eventId);
        }

        /// <summary>
        ///     Fetches a list of characters that appear in a specific event, with optional filters
        /// </summary>
        /// <param name="eventId">The event ID.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <returns></returns>
        public async Task<Response<List<Character>>> GetEventCharactersAsync(int eventId, int? limit = null,
            int? offset = null, CharacterCriteria criteria = null)
        {
            return await _characterService.GetByEventAsync(eventId, limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches a list of comics that take place during the specified event, with optional filters
        /// </summary>
        /// <param name="eventId">The event ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Comic>>> GetEventComicsAsync(int eventId, int? limit = null, int? offset = null,
            ComicCriteria criteria = null)
        {
            return await _comicService.GetByEventAsync(eventId, limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches a list of comic creators whose work appears in the specified event, with optional filters
        /// </summary>
        /// <param name="eventId">The event ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Creator>>> GetEventCreatorsAsync(int eventId, int? limit = null,
            int? offset = null, CreatorCriteria criteria = null)
        {
            return await _creatorService.GetByEventAsync(eventId, limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches a list of comic series in which the specified event takes place, with optional filters
        /// </summary>
        /// <param name="eventId">The event ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Series>>> GetEventSeriesAsync(int eventId, int? limit = null,
            int? offset = null, SeriesCriteria criteria = null)
        {
            return await _seriesService.GetByEventAsync(eventId, limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches a list of comic stories from the specified event, with optional filters
        /// </summary>
        /// <param name="eventId">The event ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Story>>> GetEventStoriesAsync(int eventId, int? limit = null,
            int? offset = null, StoryCriteria criteria = null)
        {
            return await _storyService.GetByEventAsync(eventId, limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches details for the specified comic series
        /// </summary>
        /// <param name="seriesId">The series ID.</param>
        /// <returns></returns>
        public async Task<Response<Series>> GetSeriesByIdAsync(int seriesId)
        {
            return await _seriesService.GetByIdAsync(seriesId);
        }

        /// <summary>
        ///     Fetches a list of characters that appear in the specified series, with optional filters
        /// </summary>
        /// <param name="seriesId">The series ID.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <returns></returns>
        public async Task<Response<List<Character>>> GetSeriesCharactersAsync(int seriesId, int? limit = null,
            int? offset = null, CharacterCriteria criteria = null)
        {
            return await _characterService.GetBySeriesAsync(seriesId, limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches a list of comics that are published as part of the specified series, with optional filters
        /// </summary>
        /// <param name="seriesId">The series ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Comic>>> GetSeriesComicsAsync(int seriesId, int? limit = null,
            int? offset = null, ComicCriteria criteria = null)
        {
            return await _comicService.GetBySeriesAsync(seriesId, limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches a list of comic creators whose work appears in the specified series, with optional filters
        /// </summary>
        /// <param name="seriesId">The series ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Creator>>> GetSeriesCreatorsAsync(int seriesId, int? limit = null,
            int? offset = null, CreatorCriteria criteria = null)
        {
            return await _creatorService.GetBySeriesAsync(seriesId, limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches a list of events which occur in the specified series, with optional filters
        /// </summary>
        /// <param name="seriesId">The series ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Event>>> GetSeriesEventsAsync(int seriesId, int? limit = null,
            int? offset = null, EventCriteria criteria = null)
        {
            return await _eventService.GetBySeriesAsync(seriesId, limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches a list of comic stories from the specified series, with optional filters
        /// </summary>
        /// <param name="seriesId">The series ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Story>>> GetSeriesStoriesAsync(int seriesId, int? limit = null,
            int? offset = null, StoryCriteria criteria = null)
        {
            return await _storyService.GetBySeriesAsync(seriesId, limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches details for the specified story
        /// </summary>
        /// <param name="storyId"></param>
        /// <returns></returns>
        public async Task<Response<Story>> GetStoryByIdAsync(int storyId)
        {
            return await _storyService.GetByIdAsync(storyId);
        }

        /// <summary>
        ///     Fetches a list of comic characters appearing in the specified story, with optional filters
        /// </summary>
        /// <param name="storyId">The story ID.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <returns></returns>
        public async Task<Response<List<Character>>> GetStoryCharactersAsync(int storyId, int? limit = null,
            int? offset = null, CharacterCriteria criteria = null)
        {
            return await _characterService.GetByStoryAsync(storyId, limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches a list of comics in which the specified story appears, with optional filters
        /// </summary>
        /// <param name="storyId">The story ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Comic>>> GetStoryComicsAsync(int storyId, int? limit = null, int? offset = null,
            ComicCriteria criteria = null)
        {
            return await _comicService.GetByStoryAsync(storyId, limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches a list of comic creators whose work appears in the specified story, with optional filters
        /// </summary>
        /// <param name="storyId">The story ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Creator>>> GetStoryCreatorsAsync(int storyId, int? limit = null,
            int? offset = null, CreatorCriteria criteria = null)
        {
            return await _creatorService.GetByStoryAsync(storyId, limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches a list of events in which the specified story appears, with optional filters
        /// </summary>
        /// <param name="storyId">The story ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Event>>> GetStoryEventsAsync(int storyId, int? limit = null, int? offset = null,
            EventCriteria criteria = null)
        {
            return await _eventService.GetByStoryAsync(storyId, limit, offset, criteria);
        }

        /// <summary>
        ///     Fetches a list of comic series in which the specified story takes place, with optional filters
        /// </summary>
        /// <param name="storyId">The story ID.</param>
        /// <param name="limit">Limit the result set to the specified number of resources.</param>
        /// <param name="offset">Skip the specified number of resources in the result set.</param>
        /// <param name="criteria">Filter the result set by the specified criteria.</param>
        /// <returns></returns>
        public async Task<Response<List<Series>>> GetStorySeriesAsync(int storyId, int? limit = null,
            int? offset = null, SeriesCriteria criteria = null)
        {
            return await _seriesService.GetByStoryAsync(storyId, limit, offset, criteria);
        }
    }
}