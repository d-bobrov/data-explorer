using DataExplorer.App.Services;

namespace DataExplorer.App.Tests.Services;

public class ConnectionManagerTests
{
    private readonly ConnectionManager _connectionManager;

    public ConnectionManagerTests()
    {
        _connectionManager = new ConnectionManager();
    }

    [Fact]
    public async Task CreateSqliteConnection_ShouldReturnNewGuid()
    {
        var connectionString = "Data Source=:memory:";
        var connectionId = await _connectionManager.CreateSqliteConnection(connectionString);

        Assert.NotEqual(Guid.Empty, connectionId);
    }

    [Fact]
    public async Task GetConnection_ShouldReturnConnection_WhenConnectionExists()
    {
        var connectionString = "Data Source=:memory:";
        var connectionId = await _connectionManager.CreateSqliteConnection(connectionString);

        var connection = await _connectionManager.GetConnection(connectionId);

        Assert.NotNull(connection);
    }

    [Fact]
    public async Task GetConnection_ShouldThrowException_WhenConnectionDoesNotExist()
    {
        var connectionId = Guid.NewGuid();

        await Assert.ThrowsAsync<KeyNotFoundException>(() => _connectionManager.GetConnection(connectionId));
    }

    [Fact]
    public async Task DisposeConnection_ShouldNotThrowException_WhenConnectionExists()
    {
        var connectionString = "Data Source=:memory:";
        var connectionId = await _connectionManager.CreateSqliteConnection(connectionString);

        await _connectionManager.DisposeConnection(connectionId);
    }

    [Fact]
    public async Task DisposeConnection_ShouldThrowException_WhenConnectionDoesNotExist()
    {
        var connectionId = Guid.NewGuid();

        await Assert.ThrowsAsync<KeyNotFoundException>(() => _connectionManager.DisposeConnection(connectionId));
    }

}